//-----------------------------------------------------------------------
// <copyright file="IConverter.cs" company="Junle Li">
//     Copyright (c) Junle Li. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Vsxmd
{
    /// <summary>
    /// Converter for XML document to Markdown syntax conversion.
    /// </summary>
    public interface IConverter
    {
        /// <summary>
        /// Convert to Markdown syntax.
        /// </summary>
        /// <returns>The generated Markdown content.</returns>
        string ToMarkdown();
    }
}
