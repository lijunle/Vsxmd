//-----------------------------------------------------------------------
// <copyright file="SummaryUnit.cs" company="Junle Li">
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
    /// Summary unit.
    /// </summary>
    internal class SummaryUnit : BaseUnit
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SummaryUnit"/> class.
        /// </summary>
        /// <param name="element">The summary XML element.</param>
        /// <exception cref="ArgumentException">Throw if XML element name is not <c>summary</c>.</exception>
        internal SummaryUnit(XElement element)
            : base(element, "summary")
        {
        }

        /// <inheritdoc />
        public override IEnumerable<string> ToMarkdown() =>
            new[]
            {
                "##### Summary",
                this.ElementContent,
            };

        /// <summary>
        /// Convert the summary XML element to Markdown safely.
        /// If element is <value>null</value>, return empty string.
        /// </summary>
        /// <param name="element">The summary XML element.</param>
        /// <returns>The generated Markdown.</returns>
        internal static IEnumerable<string> ToMarkdown(XElement element) =>
            element != null
                ? new SummaryUnit(element).ToMarkdown()
                : Enumerable.Empty<string>();
    }
}
