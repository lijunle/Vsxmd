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
    using System.Text.RegularExpressions;

    /// <summary>
    /// Program entry.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// Program main function entry.
        /// </summary>
        /// <param name="args">Program arguments.</param>
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
