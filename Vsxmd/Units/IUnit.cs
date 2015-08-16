//-----------------------------------------------------------------------
// <copyright file="IUnit.cs" company="Junle Li">
//     Copyright (c) Junle Li. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Vsxmd.Units
{
    using System.Collections.Generic;

    /// <summary>
    /// <see cref="IUnit"/> is wrapper to handle XML elements.
    /// </summary>
    internal interface IUnit
    {
        /// <summary>
        /// Represent the XML element content as Markdown syntax.
        /// </summary>
        /// <returns>The generated Markdown content.</returns>
        IEnumerable<string> ToMarkdown();
    }
}
