//-----------------------------------------------------------------------
// <copyright file="Converter.cs" company="Junle Li">
//     Copyright (c) Junle Li. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Vsxmd
{
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
        internal Converter(string xmlPath)
        {
            this.xmlPath = xmlPath;
        }

        /// <summary>
        /// Convert to Markdown syntax.
        /// </summary>
        /// <returns>The generated Markdown content.</returns>
        internal string ToMarkdown() =>
            $"{string.Join("\n\n", ToMarkdown(XDocument.Load(this.xmlPath)))}\n";

        private static IEnumerable<string> ToMarkdown(XDocument document)
        {
            var docElement = document.Root;

            // assembly unit
            var assemblyUnit = new AssemblyUnit(docElement.Element("assembly"));
            var assemblyMarkdown = assemblyUnit.ToMarkdown();

            // member units
            var memberUnits = docElement
                .Element("members")
                .Elements("member")
                .Select(element => new MemberUnit(element))
                .Where(member => member.Kind != MemberKind.NotSupported)
                .GroupBy(unit => unit.TypeName)
                .Select(MemberUnit.ComplementType)
                .SelectMany(group => group)
                .OrderBy(member => member, MemberUnit.Comparer);

            var memberMarkdowns = memberUnits
                .SelectMany(member => member.ToMarkdown());

            // table of contents
            var tableOfContents = new TableOfContents(memberUnits)
                .ToMarkdown();

            return tableOfContents
                .Concat(assemblyMarkdown)
                .Concat(memberMarkdowns);
        }
    }
}
