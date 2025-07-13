//-----------------------------------------------------------------------
// <copyright file="SeealsoUnit.cs" company="Junle Li">
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
    /// Seealso unit.
    /// </summary>
    internal class SeealsoUnit : BaseUnit
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SeealsoUnit"/> class.
        /// </summary>
        /// <param name="element">The seealso XML element.</param>
        /// <exception cref="ArgumentException">Throw if XML element name is not <c>seealso</c>.</exception>
        internal SeealsoUnit(XElement element)
            : base(element, "seealso")
        {
        }

        /// <inheritdoc />
        public override IEnumerable<string> ToMarkdown()
        {
            var cref = this.Element.Attribute("cref")?.Value;
            if (!string.IsNullOrEmpty(cref))
            {
                return new[] { $"- {cref.ToReferenceLink()}" };
            }

            var href = this.Element.Attribute("href")?.Value;
            if (!string.IsNullOrEmpty(href))
            {
                var text = this.ElementContent;
                if (string.IsNullOrWhiteSpace(text))
                {
                    text = href;
                }
                return new[] { $"- [{text}]({href})" };
            }

            // If neither cref nor href is present, fallback to element content
            var content = this.ElementContent;
            if (!string.IsNullOrWhiteSpace(content))
            {
                return new[] { $"- {content}" };
            }

            return new[] { "- (empty reference)" };
        }

        /// <summary>
        /// Convert the seealso XML element to Markdown safely.
        /// If element is <value>null</value>, return empty string.
        /// </summary>
        /// <param name="elements">The seealso XML element list.</param>
        /// <returns>The generated Markdown.</returns>
        internal static IEnumerable<string> ToMarkdown(IEnumerable<XElement> elements)
        {
            if (!elements.Any())
            {
                return Enumerable.Empty<string>();
            }

            var markdowns = elements
                .Select(element => new SeealsoUnit(element))
                .SelectMany(unit => unit.ToMarkdown());

            return new[]
            {
                "##### See Also",
                string.Join("\n", markdowns),
            };
        }
    }
}
