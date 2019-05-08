//-----------------------------------------------------------------------
// <copyright file="Converter.cs" company="Junle Li">
//     Copyright (c) Junle Li. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Vsxmd
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Xml.Linq;
    using Vsxmd.Reflection;
    using Vsxmd.Units;

    /// <inheritdoc/>
    public class Converter : IConverter
    {
        private readonly AssemblyReflector assembly;
        private readonly XDocument document;

        /// <summary>
        /// Initializes a new instance of the <see cref="Converter"/> class.
        /// </summary>
        /// <param name="document">The XML document.</param>
        public Converter(XDocument document)
            : this(document, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Converter"/> class.
        /// </summary>
        /// <param name="document">The XML document.</param>
        /// <param name="assembly">The owning assembly, or null if unknown.</param>
        public Converter(XDocument document, Assembly assembly)
        {
            this.assembly = new AssemblyReflector(assembly);
            this.document = document;
        }

        /// <summary>
        /// Convert VS XML document to Markdown syntax.
        /// </summary>
        /// <param name="document">The XML document.</param>
        /// <returns>The generated Markdown content.</returns>
        public static string ToMarkdown(XDocument document) =>
            new Converter(document).ToMarkdown();

        /// <inheritdoc/>
        public string ToMarkdown() => this.ToMarkdown(new ConverterSettings());

        /// <summary>
        /// Convert to Markdown syntax.
        /// </summary>
        /// <param name="settings">The settings to use during the conversion.</param>
        /// <returns>The generated Markdown content.</returns>
        public string ToMarkdown(ConverterSettings settings) =>
            ToUnits(this.document.Root, this.assembly, settings)
                .SelectMany(x => x.ToMarkdown())
                .Join("\n\n")
                .Suffix("\n");

        private static IEnumerable<IUnit> ToUnits(XElement docElement, AssemblyReflector assembly, ConverterSettings settings)
        {
            // assembly unit
            var assemblyUnit = new AssemblyUnit(docElement.Element("assembly"));

            // member units
            var memberUnits = docElement
                .Element("members")
                .Elements("member")
                .Select(element => new MemberUnit(element, assembly))
                .Where(member => member.Kind != MemberKind.NotSupported && !member.ShouldSkipMember(settings))
                .GroupBy(unit => unit.TypeName)
                .Select(group => MemberUnit.ComplementType(group, assembly))
                .SelectMany(group => group)
                .OrderBy(member => member, MemberUnit.Comparer);

            // table of contents
            var tableOfContents = new TableOfContents(memberUnits);

            return new IUnit[] { assemblyUnit }
                .Concat(new[] { tableOfContents })
                .Concat(memberUnits);
        }
    }
}
