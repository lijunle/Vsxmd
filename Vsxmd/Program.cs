//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="Junle Li">
//     Copyright (c) Junle Li. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Vsxmd
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Xml.Linq;

    /// <summary>
    /// Program entry.
    /// </summary>
    /// <remarks>
    /// Usage syntax:
    /// <code>Vsxmd.exe &lt;input-XML-path&gt; [output-Markdown-path] [should-delete-xml] [assembly-path] [should-skip-internal] [should-skip-non-browsable]</code>
    /// <para>The <c>input-XML-path</c> argument is required. It references to the VS generated XML documentation file.</para>
    /// <para>The <c>output-Markdown-path</c> argument is optional. It indicates the file path for the Markdown output file. When not specific, it will be a <c>.md</c> file with same file name as the XML documentation file, path at the XML documentation folder.</para>
    /// <para>The <c>should-delete-xml</c> argument is optional. Pass "true" to delete the original XML file after generating the markdown.</para>
    /// <para>The <c>assembly-path</c> argument is optional. It indicates the file path for the assembly corresponding to the XML file. This is needed to support the skip arguments.</para>
    /// <para>The <c>should-skip-internal</c> argument is optional. Pass "true" to exclude internal types and members from the markdown. Requires the assembly-path argument.</para>
    /// <para>The <c>should-skip-non-browsable</c> argument is optional. Pass "true" to exclude types and members marked with the <see cref="System.ComponentModel.EditorBrowsableAttribute"/> with a value of <see cref="System.ComponentModel.EditorBrowsableState.Never"/>. Requires the assembly-path argument.</para>
    /// </remarks>
    internal static class Program
    {
        /// <summary>
        /// Program main function entry.
        /// </summary>
        /// <param name="args">Program arguments.</param>
        /// <seealso cref="Program"/>
        internal static void Main(string[] args)
        {
            try
            {
                if (args == null || args.Length < 1)
                {
                    return;
                }

                string xmlPath = args[0];
                string markdownPath = args.ElementAtOrDefault(1);

                if (string.IsNullOrWhiteSpace(markdownPath))
                {
                    // replace extension with `md` extension
                    markdownPath = Path.ChangeExtension(xmlPath, ".md");
                }

                Assembly assembly = null;
                string assemblyPath = args.ElementAtOrDefault(3);
                var settings = new ConverterSettings
                {
                    ShouldSkipInternal = BoolArgumentOrDefault(args, 4),
                    ShouldSkipNonBrowsable = BoolArgumentOrDefault(args, 5),
                };

                if (settings.ShouldSkipInternal || settings.ShouldSkipNonBrowsable)
                {
                    if (string.IsNullOrWhiteSpace(assemblyPath))
                    {
                        Console.WriteLine("Assembly path must be supplied when skipping members");
                        return;
                    }

                    AppDomain.CurrentDomain.AssemblyResolve += (s, e) => ResolveDependency(Path.GetDirectoryName(assemblyPath), e);
                    assembly = Assembly.LoadFile(assemblyPath);
                }

                var document = XDocument.Load(xmlPath);
                var converter = new Converter(document, assembly);
                var markdown = converter.ToMarkdown(settings);

                File.WriteAllText(markdownPath, markdown);

                var shouldDelete = BoolArgumentOrDefault(args, 2);
                if (shouldDelete)
                {
                    File.Delete(xmlPath);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                // Ignore errors. Do not impact on project build
                return;
            }
        }

        private static bool BoolArgumentOrDefault(string[] args, int index)
        {
            string arg = args.ElementAtOrDefault(index);
            if (string.IsNullOrWhiteSpace(arg))
            {
                return false;
            }

            return Convert.ToBoolean(arg, CultureInfo.InvariantCulture);
        }

        private static Assembly ResolveDependency(string searchPath, ResolveEventArgs args)
        {
            // Look for missing dependencies next to the assembly we loaded originally.
            var assemblyPath = Path.Combine(searchPath, new AssemblyName(args.Name).Name + ".dll");
            if (File.Exists(assemblyPath))
            {
                return Assembly.LoadFile(assemblyPath);
            }

            return null;
        }

        private class Test
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="Test"/> class.
            /// <para>Test constructor without parameters.</para>
            /// <para>See <see cref="Test()"/>.</para>
            /// </summary>
            /// <permission cref="Program">Just for test.</permission>
            internal Test()
            {
            }

#pragma warning disable SA1614 // Element parameter documentation must have text
            /// <summary>
            /// Test a param tag without description.
            /// </summary>
            /// <param name="p"></param>
            /// <returns>Nothing.</returns>
            internal string TestParamWithoutDescription(string p) => null;
#pragma warning restore SA1614 // Element parameter documentation must have text

            /// <summary>
            /// Test generic reference type.
            /// <para>See <see cref="TestGenericParameter{T1, T2}(Expression{Func{T1, T2, string}})"/>.</para>
            /// </summary>
            /// <returns>Nothing.</returns>
            internal string TestGenericReference() => null;

            /// <summary>
            /// Test generic parameter type.
            /// <para>See <typeparamref name="T1"/> and <typeparamref name="T2"/>.</para>
            /// </summary>
            /// <typeparam name="T1">Generic type 1.</typeparam>
            /// <typeparam name="T2">Generic type 2.</typeparam>
            /// <param name="expression">The linq expression.</param>
            /// <returns>Nothing.</returns>
            internal string TestGenericParameter<T1, T2>(
                Expression<Func<T1, T2, string>> expression) =>
                null;

            /// <summary>
            /// Test generic exception type.
            /// </summary>
            /// <returns>Nothing.</returns>
            /// <exception cref="TestGenericParameter{T1, T2}(Expression{Func{T1, T2, string}})">Just for test.</exception>
            internal string TestGenericException() => null;

            /// <summary>
            /// Test generic exception type.
            /// </summary>
            /// <returns>Nothing.</returns>
            /// <permission cref="TestGenericParameter{T1, T2}(Expression{Func{T1, T2, string}})">Just for test.</permission>
            internal string TestGenericPermission() => null;

            /// <summary>
            /// Test backtick characters in summary comment.
            /// <para>See `should not inside code block`.</para>
            /// <para>See <c>`backtick inside code block`</c>.</para>
            /// <para>See `<c>code block inside backtick</c>`.</para>
            /// </summary>
            /// <returns>Nothing.</returns>
            internal string TestBacktickInSummary() => null;

            /// <summary>
            /// Test space after inline elements.
            /// <para>See <c>code block</c> should follow a space.</para>
            /// <para>See a value at the end of a <value>sentence</value>.</para>
            /// <para>See <see cref="TestSpaceAfterInlineElements"/> as a link.</para>
            /// <para>See <paramref name="space" /> after a param ref.</para>
            /// <para>See <typeparamref name="T" /> after a type param ref.</para>
            /// </summary>
            /// <returns>Nothing.</returns>
            internal bool TestSpaceAfterInlineElements<T>(bool space) => space;

            /// <summary>
            /// Test see tag with langword attribute. See <see langword="true"/>.
            /// </summary>
            /// <returns>Nothing.</returns>
            internal string TestSeeLangword() => null;
        }

        /// <summary>
        /// Test generic type.
        /// <para>See <see cref="TestGenericType{T1, T2}"/>.</para>
        /// </summary>
        /// <typeparam name="T1">Generic type 1.</typeparam>
        /// <typeparam name="T2">Generic type 2.</typeparam>
        private class TestGenericType<T1, T2>
        {
            /// <summary>
            /// Test generic method.
            /// <para>See <see cref="TestGenericMethod{T3, T4}"/>.</para>
            /// </summary>
            /// <typeparam name="T3">Generic type 3.</typeparam>
            /// <typeparam name="T4">Generic type 4.</typeparam>
            /// <returns>Nothing.</returns>
            internal string TestGenericMethod<T3, T4>() => null;
        }
    }
}
