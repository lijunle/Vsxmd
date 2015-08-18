//-----------------------------------------------------------------------
// <copyright file="TableOfContents.cs" company="Junle Li">
//     Copyright (c) Junle Li. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Vsxmd
{
    using System.Collections.Generic;
    using System.Linq;
    using Units;

    /// <summary>
    /// Table of contents.
    /// </summary>
    internal class TableOfContents
    {
        private readonly IOrderedEnumerable<MemberUnit> memberUnits;

        /// <summary>
        /// Initializes a new instance of the <see cref="TableOfContents"/> class.
        /// <para>It convert the table of contents from the <paramref name="memberUnits"/>.</para>
        /// </summary>
        /// <param name="memberUnits">The member unit list.</param>
        internal TableOfContents(IOrderedEnumerable<MemberUnit> memberUnits)
        {
            this.memberUnits = memberUnits;
        }

        /// <summary>
        /// Convert the table of contents to Markdown syntax.
        /// </summary>
        /// <returns>The table of contents in Markdown syntax.</returns>
        internal IEnumerable<string> ToMarkdown() =>
            new[]
            {
                "# Contents",
                this.memberUnits.Select(ToMarkdown).Join("\n")
            };

        private static string ToMarkdown(MemberUnit memberUnit) =>
            $"{GetIndentation(memberUnit)}- {memberUnit.Link}";

        private static string GetIndentation(MemberUnit memberUnit) =>
            memberUnit.Kind == MemberKind.Type ? string.Empty : "  ";
    }
}
