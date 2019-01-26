//-----------------------------------------------------------------------
// <copyright file="ExceptionUnit.cs" company="Junle Li">
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
    /// Exception unit.
    /// </summary>
    internal class ExceptionUnit : BaseUnit
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionUnit"/> class.
        /// </summary>
        /// <param name="element">The exception XML element.</param>
        /// <exception cref="ArgumentException">Throw if XML element name is not <c>exception</c>.</exception>
        internal ExceptionUnit(XElement element)
            : base(element, "exception")
        {
        }

        private string Name => this.GetAttribute("cref").ToReferenceLink();

        private string Description => this.ElementContent;

        /// <inheritdoc />
        public override IEnumerable<string> ToMarkdown() =>
            new[]
            {
                $"| {this.Name} | {this.Description} |",
            };

        /// <summary>
        /// Convert the exception XML element to Markdown safely.
        /// If element is <value>null</value>, return empty string.
        /// </summary>
        /// <param name="elements">The exception XML element list.</param>
        /// <returns>The generated Markdown.</returns>
        internal static IEnumerable<string> ToMarkdown(IEnumerable<XElement> elements)
        {
            if (!elements.Any())
            {
                return Enumerable.Empty<string>();
            }

            var markdowns = elements
                .Select(element => new ExceptionUnit(element))
                .SelectMany(unit => unit.ToMarkdown());

            var table = new[]
            {
                "| Name | Description |",
                "| ---- | ----------- |",
            }
            .Concat(markdowns);

            return new[]
            {
                "##### Exceptions",
                string.Join("\n", table),
            };
        }
    }
}
