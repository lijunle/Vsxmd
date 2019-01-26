//-----------------------------------------------------------------------
// <copyright file="RemarksUnit.cs" company="Junle Li">
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
    /// Remarks unit.
    /// </summary>
    internal class RemarksUnit : BaseUnit
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RemarksUnit"/> class.
        /// </summary>
        /// <param name="element">The remarks XML element.</param>
        /// <exception cref="ArgumentException">Throw if XML element name is not <c>remarks</c>.</exception>
        internal RemarksUnit(XElement element)
            : base(element, "remarks")
        {
        }

        /// <inheritdoc />
        public override IEnumerable<string> ToMarkdown() =>
            new[]
            {
                "##### Remarks",
                this.ElementContent,
            };

        /// <summary>
        /// Convert the remarks XML element to Markdown safely.
        /// If element is <value>null</value>, return empty string.
        /// </summary>
        /// <param name="element">The remarks XML element.</param>
        /// <returns>The generated Markdown.</returns>
        internal static IEnumerable<string> ToMarkdown(XElement element) =>
            element != null
                ? new RemarksUnit(element).ToMarkdown()
                : Enumerable.Empty<string>();
    }
}
