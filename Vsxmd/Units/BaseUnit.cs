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
        internal BaseUnit(XElement element, string elementName)
        {
            if (element.Name != elementName)
            {
                throw new ArgumentException("The element name is not expected", nameof(element));
            }

            this.Element = element;
        }

        /// <summary>
        /// Gets the XML element.
        /// </summary>
        /// <value>The XML element.</value>
        protected XElement Element { get; }

        /// <summary>
        /// Gets the Markdown content representing the element.
        /// </summary>
        /// <value>The Markdown content.</value>
        protected string ElementContent => this.Element.ToMarkdownText();

        /// <inheritdoc />
        public abstract IEnumerable<string> ToMarkdown();

        /// <summary>
        /// Gets the first (in document order) child element with the specified <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The <see cref="XName"/> to match.</param>
        /// <returns>A <see cref="XName"/> that matches the specified <paramref name="name"/>, or <value>null</value>.</returns>
        protected XElement GetChild(XName name) =>
            this.Element.Element(name);

        /// <summary>
        /// Returns a collection of the child elements of this element or document, in document order.
        /// Only elements that have a matching <see cref="XName"/> are included in the collection.
        /// </summary>
        /// <param name="name">The <see cref="XName"/> to match.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="XElement"/> containing the children that have a matching <see cref="XName"/>, in document order.</returns>
        protected IEnumerable<XElement> GetChildren(XName name) =>
            this.Element.Elements(name);

        /// <summary>
        /// Returns the <see cref="XAttribute"/> value of this <see cref="XElement"/> that has the specified <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The <see cref="XName"/> of the <see cref="XAttribute"/> to get.</param>
        /// <returns>An <see cref="XAttribute"/> value that has the specified <paramref name="name"/>; <value>null</value> if there is no attribute with the specified <paramref name="name"/>.</returns>
        protected string GetAttribute(XName name) =>
            this.Element.Attribute(name).Value;
    }
}
