//-----------------------------------------------------------------------
// <copyright file="MemberName.cs" company="Junle Li">
//     Copyright (c) Junle Li. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Vsxmd.Units
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Member name.
    /// </summary>
    internal class MemberName
    {
        private readonly string name;

        private readonly char type;

        /// <summary>
        /// Initializes a new instance of the <see cref="MemberName"/> class.
        /// </summary>
        /// <param name="name">The raw member name. For example, <c>T:Vsxmd.Units.MemberName</c>.</param>
        internal MemberName(string name)
        {
            this.name = name;
            this.type = name.First();
        }

        /// <summary>
        /// Gets the member kind, one of <see cref="MemberKind"/>.
        /// </summary>
        /// <value>The member kind.</value>
        private MemberKind Kind =>
            this.type == 'T'
            ? MemberKind.Type
            : this.type == 'F'
            ? MemberKind.Constants
            : this.type == 'P'
            ? MemberKind.Property
            : this.type == 'M' && this.name.Contains(".#ctor")
            ? MemberKind.Constructor
            : this.type == 'M' && !this.name.Contains(".#ctor")
            ? MemberKind.Method
            : MemberKind.NotSupported;

        private string Namespace =>
            this.Kind == MemberKind.Type
            ? this.NameSegments.TakeAllButLast(1).Join(".")
            : this.Kind == MemberKind.Constants ||
              this.Kind == MemberKind.Property ||
              this.Kind == MemberKind.Constructor ||
              this.Kind == MemberKind.Method
            ? this.NameSegments.TakeAllButLast(2).Join(".")
            : string.Empty;

        private string TypeShortName =>
            this.Kind == MemberKind.Type
            ? this.NameSegments.Last()
            : this.Kind == MemberKind.Constants ||
              this.Kind == MemberKind.Property ||
              this.Kind == MemberKind.Constructor ||
              this.Kind == MemberKind.Method
            ? this.NameSegments.NthLast(2)
            : string.Empty;

        private string Href => this.name
            .Replace(':', '-')
            .Replace('(', '-')
            .Replace(')', '-');

        private string LongName =>
            this.name.Split('(').First().Split(':').Last();

        private string MsdnName =>
            this.LongName.Split('{').First();

        private IEnumerable<string> NameSegments =>
            this.LongName.Split('.');

        /// <summary>
        /// Convert the member name to Markdown reference link.
        /// <para>If then name is under <c>System</c> namespace, the link points to MSDN.</para>
        /// <para>Otherwise, the link points to this page anchor.</para>
        /// </summary>
        /// <returns>The generated Markdown reference link.</returns>
        internal string ToReferenceLink() =>
            $"{this.Namespace}.".StartsWith("System.")
            ? $"[{this.LongName.Escape()}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:{this.MsdnName})"
            : $"[{this.LongName.Escape()}](#{this.Href})";
    }
}
