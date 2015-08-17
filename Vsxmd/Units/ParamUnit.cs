//-----------------------------------------------------------------------
// <copyright file="ParamUnit.cs" company="Junle Li">
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
    /// Param unit.
    /// </summary>
    internal class ParamUnit : BaseUnit
    {
        private readonly string paramType;

        /// <summary>
        /// Initializes a new instance of the <see cref="ParamUnit"/> class.
        /// </summary>
        /// <param name="element">The param XML element.</param>
        /// <param name="paramType">The paramter type corresponding to the param XML element.</param>
        /// <exception cref="ArgumentException">Throw if XML element name is not <c>param</c>.</exception>
        public ParamUnit(XElement element, string paramType)
            : base(element, "param")
        {
            this.paramType = paramType;
        }

        private string Name => this.Element.Attribute("name").Value;

        private string Description => this.Element.ToMarkdownText();

        /// <inheritdoc />
        public override IEnumerable<string> ToMarkdown() =>
            new[]
            {
                $"| {this.Name} | {this.paramType} | {this.Description} |"
            };

        /// <summary>
        /// Convert the param XML element to Markdown safely.
        /// If elemnt is <value>null</value>, return empty string.
        /// </summary>
        /// <param name="elements">The param XML element list.</param>
        /// <param name="paramTypes">The paramater type names.</param>
        /// <returns>The generated Markdown.</returns>
        internal static IEnumerable<string> ToMarkdown(
            IEnumerable<XElement> elements,
            IEnumerable<string> paramTypes)
        {
            var markdowns = elements
                .Zip(paramTypes, (element, type) => new ParamUnit(element, type))
                .SelectMany(unit => unit.ToMarkdown());

            var table = new[]
            {
                "| Name | Type | Description |",
                "| ---- | ---- | ----------- |"
            }
            .Concat(markdowns);

            return new[]
            {
                "##### Parameters",
                markdowns.Any()
                    ? string.Join("\n", table)
                    : "This method has no parameters."
            };
        }
    }
}
