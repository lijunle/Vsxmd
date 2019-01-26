//-----------------------------------------------------------------------
// <copyright file="PermissionUnit.cs" company="Junle Li">
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
    /// Permission unit.
    /// </summary>
    internal class PermissionUnit : BaseUnit
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PermissionUnit"/> class.
        /// </summary>
        /// <param name="element">The permission XML element.</param>
        /// <exception cref="ArgumentException">Throw if XML element name is not <c>permission</c>.</exception>
        internal PermissionUnit(XElement element)
            : base(element, "permission")
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
        /// Convert the permission XML element to Markdown safely.
        /// If element is <value>null</value>, return empty string.
        /// </summary>
        /// <param name="elements">The permission XML element list.</param>
        /// <returns>The generated Markdown.</returns>
        internal static IEnumerable<string> ToMarkdown(IEnumerable<XElement> elements)
        {
            if (!elements.Any())
            {
                return Enumerable.Empty<string>();
            }

            var markdowns = elements
                .Select(element => new PermissionUnit(element))
                .SelectMany(unit => unit.ToMarkdown());

            var table = new[]
            {
                "| Name | Description |",
                "| ---- | ----------- |",
            }
            .Concat(markdowns);

            return new[]
            {
                "##### Permissions",
                string.Join("\n", table),
            };
        }
    }
}
