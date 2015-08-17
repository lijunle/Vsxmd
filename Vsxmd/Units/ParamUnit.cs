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

        private string Name => this.GetAttribute("name");

        private string Description => this.ElementContent;

        /// <inheritdoc />
        public override IEnumerable<string> ToMarkdown() =>
            new[]
            {
                $"| {this.Name} | {this.paramType.Escape()} | {this.Description} |"
            };

        /// <summary>
        /// Convert the param XML element to Markdown safely.
        /// </summary>
        /// <param name="elements">The param XML element list.</param>
        /// <param name="paramTypes">The paramater type names.</param>
        /// <param name="isParameterKind">Indicates if the member kind have parameters, which is constructor or methods.</param>
        /// <returns>The generated Markdown.</returns>
        /// <remarks>
        /// When the parameter (a.k.a <paramref name="elements"/>) list is empty:
        /// <para>If parent element kind is constructor or method, it returns a hint about "no parameters".</para>
        /// <para>If parent element kind is not the value mentioned above, it returns an empty string.</para>
        /// </remarks>
        internal static IEnumerable<string> ToMarkdown(
            IEnumerable<XElement> elements,
            IEnumerable<string> paramTypes,
            bool isParameterKind)
        {
            if (!elements.Any())
            {
                return !isParameterKind
                    ? Enumerable.Empty<string>()
                    : new[]
                    {
                        "##### Parameters",
                        "This method has no parameters."
                    };
            }

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
                string.Join("\n", table)
            };
        }
    }
}
