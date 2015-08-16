//-----------------------------------------------------------------------
// <copyright file="Converter.cs" company="Junle Li">
//     Copyright (c) Junle Li. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Vsxmd
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using Units;

    /// <summary>
    /// Convert from XML docuement to Markdown syntax.
    /// </summary>
    internal class Converter
    {
        private readonly string xmlPath;

        /// <summary>
        /// Initializes a new instance of the <see cref="Converter"/> class.
        /// </summary>
        /// <param name="xmlPath">The XML document path.</param>
        public Converter(string xmlPath)
        {
            this.xmlPath = xmlPath;
        }

        /// <summary>
        /// Convert to Markdown syntax.
        /// </summary>
        /// <returns>The generated Markdown content.</returns>
        public string ToMarkdown() =>
            $"{string.Join("\n\n", ToMarkdown(XDocument.Load(this.xmlPath)))}\n";

        private static IEnumerable<string> ToMarkdown(XDocument document)
        {
            var docElement = document.Root;

            // assembly unit
            var assemblyUnit = new AssemblyUnit(docElement.Element("assembly"));
            var assemblyMarkdown = assemblyUnit.ToMarkdown();

            return assemblyMarkdown;
        }
    }
}
