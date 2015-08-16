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
    using System.Security;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Program entry.
    /// </summary>
    /// <remarks>
    /// Usage syntax:
    /// <c>Vsxmd.exe &lt;input-XML-path&gt; [output-Markdown-path]</c>
    /// <para>The <c>input-XML-path</c> argument is required. It references to the VS generated XML documentation file.</para>
    /// <para>The <c>output-Markdown-path</c> argument is optional. It indicates the file path for the Markdown output file. When not specific, it will be a <c>.md</c> file with same file name as the XML documentation file, path at the XML documentation folder.</para>
    /// </remarks>
    /// <permission cref="PermissionSet">Vsxmd provides no program APIs.</permission>
    internal static class Program
    {
        /// <summary>
        /// Program main function entry.
        /// </summary>
        /// <param name="args">Program arguments.</param>
        /// <seealso cref="Program"/>
        internal static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.Error.WriteLine($"Usage: {AppDomain.CurrentDomain.FriendlyName} <input-XML-path> [output-Markdown-path]");
                Environment.Exit(1);
            }

            string xmlPath = args[0];
            string markdownPath = args.ElementAtOrDefault(1);

            if (markdownPath == null)
            {
                // replace the `xml` extension with `md` extension
                markdownPath = Regex.Replace(xmlPath, @"\.xml$", ".md", RegexOptions.IgnoreCase);
            }

            var converter = new Converter(xmlPath);
            var markdown = converter.ToMarkdown();

            File.WriteAllText(markdownPath, markdown);
        }
    }
}
