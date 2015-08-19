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

    /// <inheritdoc/>
    internal class Converter : IConverter
    {
        private readonly XDocument document;

        /// <summary>
        /// Initializes a new instance of the <see cref="Converter"/> class.
        /// </summary>
        /// <param name="document">The XML document.</param>
        internal Converter(XDocument document)
        {
            this.document = document;
        }

        /// <inheritdoc/>
        public string ToMarkdown() =>
            ToUnits(this.document.Root)
                .SelectMany(x => x.ToMarkdown())
                .Join("\n\n")
                .Suffix("\n");

        private static IEnumerable<IUnit> ToUnits(XElement docElement)
        {
            // assembly unit
            var assemblyUnit = new AssemblyUnit(docElement.Element("assembly"));

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

            // table of contents
            var tableOfContents = new TableOfContents(memberUnits);

            return new IUnit[] { tableOfContents }
                .Concat(new[] { assemblyUnit })
                .Concat(memberUnits);
        }
    }
}
