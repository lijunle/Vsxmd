//-----------------------------------------------------------------------
// <copyright file="ExampleUnit.cs" company="Junle Li">
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
    /// Example unit.
    /// </summary>
    internal class ExampleUnit : BaseUnit
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExampleUnit"/> class.
        /// </summary>
        /// <param name="element">The example XML element.</param>
        /// <exception cref="ArgumentException">Throw if XML element name is not <c>example</c>.</exception>
        internal ExampleUnit(XElement element)
            : base(element, "example")
        {
        }

        /// <inheritdoc />
        public override IEnumerable<string> ToMarkdown() =>
            new[]
            {
                $"##### Example",
                $"{this.ElementContent}",
            };

        /// <summary>
        /// Convert the example XML element to Markdown safely.
        /// If element is <value>null</value>, return empty string.
        /// </summary>
        /// <param name="element">The example XML element.</param>
        /// <returns>The generated Markdown.</returns>
        internal static IEnumerable<string> ToMarkdown(XElement element) =>
            element != null
                ? new ExampleUnit(element).ToMarkdown()
                : Enumerable.Empty<string>();
    }
}
