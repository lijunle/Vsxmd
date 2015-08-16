//-----------------------------------------------------------------------
// <copyright file="BaseUnit.cs" company="Junle Li">
//     Copyright (c) Junle Li. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Vsxmd.Units
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Linq;

    /// <summary>
    /// The base unit.
    /// </summary>
    internal abstract class BaseUnit : IUnit
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseUnit"/> class.
        /// </summary>
        /// <param name="element">The XML element.</param>
        /// <param name="elementName">The expected XML element name.</param>
        /// <exception cref="ArgumentException">Throw if XML <paramref name="element"/> name not matches the expected <paramref name="elementName"/>.</exception>
        public BaseUnit(XElement element, string elementName)
        {
            if (element.Name != elementName)
            {
                throw new ArgumentException(nameof(element));
            }

            this.Element = element;
        }

        /// <summary>
        /// Gets the XML element.
        /// </summary>
        /// <value>The XML element.</value>
        protected XElement Element { get; }

        /// <inheritdoc />
        public abstract IEnumerable<string> ToMarkdown();
    }
}
