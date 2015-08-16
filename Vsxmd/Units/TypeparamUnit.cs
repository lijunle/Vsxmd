//-----------------------------------------------------------------------
// <copyright file="TypeparamUnit.cs" company="Junle Li">
//     Copyright (c) Junle Li. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Vsxmd.Units
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    /// <summary>
    /// Typeparam unit.
    /// </summary>
    internal class TypeparamUnit : BaseUnit
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TypeparamUnit"/> class.
        /// </summary>
        /// <param name="element">The typeparam XML element.</param>
        /// <exception cref="ArgumentException">Throw if XML element name is not <c>typeparam</c>.</exception>
        public TypeparamUnit(XElement element)
            : base(element, "typeparam")
        {
        }

        private string TypeName => this.Element.Attribute("name").Value;

        private string TypeDescription => this.Element.ToMarkdownText();

        /// <inheritdoc />
        public override IEnumerable<string> ToMarkdown() =>
            new[]
            {
                $"| {this.TypeName} | {this.TypeDescription} |"
            };

        /// <summary>
        /// Convert the param XML element to Markdown safely.
        /// If elemnt is <value>null</value>, return empty string.
        /// </summary>
        /// <param name="elements">The param XML element list.</param>
        /// <returns>The generated Markdown.</returns>
        internal static IEnumerable<string> ToMarkdown(IEnumerable<XElement> elements)
        {
            if (!elements.Any())
            {
                return Enumerable.Empty<string>();
            }

            var typeparamMarkdowns = elements
                .Select(element => new TypeparamUnit(element))
                .SelectMany(unit => unit.ToMarkdown());

            var paramTable = new[]
            {
                "| Name | Description |",
                "| ---- | ----------- |"
            }
            .Concat(typeparamMarkdowns);

            return new[]
            {
                "##### Generic Types",
                string.Join("\n", paramTable)
            };
        }
    }
}
