//-----------------------------------------------------------------------
// <copyright file="AssemblyUnit.cs" company="Junle Li">
//     Copyright (c) Junle Li. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Vsxmd.Units
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Linq;

    /// <summary>
    /// Assembly unit.
    /// </summary>
    internal class AssemblyUnit : IUnit
    {
        private readonly XElement element;

        /// <summary>
        /// Initializes a new instance of the <see cref="AssemblyUnit"/> class.
        /// </summary>
        /// <param name="element">The assembly XML element.</param>
        /// <exception cref="ArgumentException">Throw if XML element name is not <c>assembly</c>.</exception>
        public AssemblyUnit(XElement element)
        {
            if (element.Name != "assembly")
            {
                throw new ArgumentException(nameof(element));
            }

            this.element = element;
        }

        private string AssemblyName => this.element.Element("name").Value;

        /// <inheritdoc />
        public IEnumerable<string> ToMarkdown() =>
            new[]
            {
                $"# {this.AssemblyName}"
            };
    }
}
