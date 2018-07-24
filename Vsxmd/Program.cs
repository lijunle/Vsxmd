//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="Junle Li">
//     Copyright (c) Junle Li. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Vsxmd
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Security;
    using System.Xml.Linq;

    /// <summary>
    /// Program entry.
    /// </summary>
    /// <remarks>
    /// Usage syntax:
    /// <c>Vsxmd.exe &lt;input-XML-path&gt; [output-Markdown-path]</c>
    /// <para>The <c>input-XML-path</c> argument is required. It references to the VS generated XML documentation file.</para>
    /// <para>The <c>output-Markdown-path</c> argument is optional. It indicates the file path for the Markdown output file. When not specific, it will be a <c>.md</c> file with same file name as the XML documentation file, path at the XML documentation folder.</para>
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

                var document = XDocument.Load(xmlPath);
                var converter = new Converter(document);
                var markdown = converter.ToMarkdown();

                File.WriteAllText(markdownPath, markdown);

                string vsxmdAutoDeleteXml = args.ElementAtOrDefault(2);
                if (string.IsNullOrWhiteSpace(vsxmdAutoDeleteXml))
                {
                    return;
                }

                var shouldDelete = Convert.ToBoolean(vsxmdAutoDeleteXml);
                if (shouldDelete)
                {
                    File.Delete(xmlPath);
                }
            }
            catch (Exception)
            {
                // Ignore errors. Do not impact on project build
                return;
            }
        }

        private class Test
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="Test"/> class.
            /// <para>Test constructor without parameters.</para>
            /// <para>See <see cref="Test()"/></para>
            /// </summary>
            /// <permission cref="PermissionSet">Just for test.</permission>
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
            internal string TestGenericRefence() => null;

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
            /// <para>See <c>`backtick inside code block`</c></para>
            /// <para>See `<c>code block inside backtick</c>`</para>
            /// </summary>
            /// <returns>Nothing.</returns>
            internal string TestBacktickInSummary() => null;

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
            /// <para>See <see cref="TestGenericMethod{T3, T4}"/></para>
            /// </summary>
            /// <typeparam name="T3">Generic type 3.</typeparam>
            /// <typeparam name="T4">Generic type 4.</typeparam>
            /// <returns>Nothing.</returns>
            internal string TestGenericMethod<T3, T4>() => null;
        }
    }
}
