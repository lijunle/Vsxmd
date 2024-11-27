//-----------------------------------------------------------------------
// <copyright file="MemberName.cs" company="Junle Li">
//     Copyright (c) Junle Li. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Vsxmd.Units
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Member name.
    /// </summary>
    internal class MemberName : IComparable<MemberName>
    {
        private readonly string name;

        private readonly char type;

        private readonly IEnumerable<string> paramNames;

        /// <summary>
        /// Initializes a new instance of the <see cref="MemberName"/> class.
        /// </summary>
        /// <param name="name">The raw member name. For example, <c>T:Vsxmd.Units.MemberName</c>.</param>
        /// <param name="paramNames">The parameter names. It is only used when member kind is <see cref="MemberKind.Constructor"/> or <see cref="MemberKind.Method"/>.</param>
        internal MemberName(string name, IEnumerable<string> paramNames)
        {
            this.name = name;
            this.type = name.First();
            this.paramNames = paramNames;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MemberName"/> class.
        /// </summary>
        /// <param name="name">The raw member name. For example, <c>T:Vsxmd.Units.MemberName</c>.</param>
        internal MemberName(string name)
            : this(name, null)
        {
        }

        /// <summary>
        /// Gets the member kind, one of <see cref="MemberKind"/>.
        /// </summary>
        /// <value>The member kind.</value>
        internal MemberKind Kind =>
            this.type == 'T'
            ? MemberKind.Type
            : this.type == 'F'
            ? MemberKind.Constants
            : this.type == 'P'
            ? MemberKind.Property
            : this.type == 'M' && this.name.Contains(".#ctor", StringComparison.InvariantCulture)
            ? MemberKind.Constructor
            : this.type == 'M' && !this.name.Contains(".#ctor", StringComparison.InvariantCulture)
            ? MemberKind.Method
            : MemberKind.NotSupported;

        /// <summary>
        /// Gets the link pointing to this member unit.
        /// </summary>
        /// <value>The link pointing to this member unit.</value>
        internal string Link =>
            this.Kind == MemberKind.Type ||
            this.Kind == MemberKind.Constants ||
            this.Kind == MemberKind.Property
            ? $"[{this.FriendlyName.Escape()}](#{this.Href})"
            : this.Kind == MemberKind.Constructor ||
              this.Kind == MemberKind.Method
            ? $"[{this.FriendlyName.Escape()}({this.paramNames.Join(",")})](#{this.Href})"
            : string.Empty;

        /// <summary>
        /// Gets the caption representation for this member name.
        /// </summary>
        /// <value>The caption.</value>
        /// <example>
        /// <para>For <see cref="MemberKind.Type"/>, show as <c>## Vsxmd.Units.MemberName [#](#here) [^](#contents)</c>.</para>
        /// <para>For other kinds, show as <c>### Vsxmd.Units.MemberName.Caption [#](#here) [^](#contents)</c>.</para>
        /// </example>
        internal string Caption =>
            this.Kind == MemberKind.Type
            ? $"{this.Href.ToAnchor()}## {this.FriendlyName.Escape()} `{this.Kind.ToLowerString()}`"
            : this.Kind == MemberKind.Constants ||
              this.Kind == MemberKind.Property
            ? $"{this.Href.ToAnchor()}### {this.FriendlyName.Escape()} `{this.Kind.ToLowerString()}`"
            : this.Kind == MemberKind.Constructor ||
              this.Kind == MemberKind.Method
            ? $"{this.Href.ToAnchor()}### {this.FriendlyName.Escape()}({this.paramNames.Join(",")}) `{this.Kind.ToLowerString()}`"
            : string.Empty;

        /// <summary>
        /// Gets the type name.
        /// </summary>
        /// <value>The type name.</value>
        /// <example><c>Vsxmd.Program</c>, <c>Vsxmd.Units.TypeUnit</c>.</example>
        internal string TypeName =>
            $"{this.Namespace}.{this.TypeShortName}";

        /// <summary>
        /// Gets the namespace name.
        /// </summary>
        /// <value>The namespace name.</value>
        /// <example><c>System</c>, <c>Vsxmd</c>, <c>Vsxmd.Units</c>.</example>
        internal string Namespace =>
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
            .Replace('.', '-')
            .Replace(':', '-')
            .Replace('(', '-')
            .Replace(')', '-')
            .ToLower()
            [2..];

        private string StrippedName =>
            this.name.Substring(2);

        private string LongName =>
            this.StrippedName.Split('(').First();

        private string MsdnName =>
            this.LongName.Split('{').First();

        private IEnumerable<string> NameSegments =>
            this.LongName.Split('.');

        private string FriendlyName =>
            this.Kind == MemberKind.Type
            ? this.TypeShortName
            : this.Kind == MemberKind.Constants ||
              this.Kind == MemberKind.Property ||
              this.Kind == MemberKind.Constructor ||
              this.Kind == MemberKind.Method
            ? this.NameSegments.Last()
            : string.Empty;

        /// <inheritdoc />
        public int CompareTo(MemberName other) =>
            this.TypeShortName != other.TypeShortName
            ? string.Compare(this.TypeShortName, other.TypeShortName, StringComparison.Ordinal)
            : this.Kind != other.Kind
            ? this.Kind.CompareTo(other.Kind)
            : string.Compare(this.LongName, other.LongName, StringComparison.Ordinal);

        /// <summary>
        /// Gets the method parameter type names from the member name.
        /// </summary>
        /// <returns>The method parameter type name list.</returns>
        /// <example>
        /// It will prepend the type kind character (<c>T:</c>) to the type string.
        /// <para>For <c>(System.String,System.Int32)</c>, returns <c>["T:System.String","T:System.Int32"]</c>.</para>
        /// It also handle generic type.
        /// <para>For <c>(System.Collections.Generic.IEnumerable{System.String})</c>, returns <c>["T:System.Collections.Generic.IEnumerable{System.String}"]</c>.</para>
        /// </example>
        internal IEnumerable<string> GetParamTypes()
        {
            var paramString = this.name.Split('(').Last().Trim(')');

            var delta = 0;
            var list = new List<StringBuilder>()
            {
                new StringBuilder("T:"),
            };

            foreach (var character in paramString)
            {
                if (character == '{')
                {
                    delta++;
                }
                else if (character == '}')
                {
                    delta--;
                }
                else if (character == ',' && delta == 0)
                {
                    list.Add(new StringBuilder("T:"));
                }

                if (character != ',' || delta != 0)
                {
                    list.Last().Append(character);
                }
            }

            return list.Select(x => x.ToString());
        }

        /// <summary>
        /// Convert the member name to Markdown reference link.
        /// <para>If then name is under <c>System</c> namespace, the link points to MSDN.</para>
        /// <para>Otherwise, the link points to this page anchor.</para>
        /// </summary>
        /// <param name="useShortName">Indicate if use short type name.</param>
        /// <returns>The generated Markdown reference link.</returns>
        internal string ToReferenceLink(bool useShortName) =>
            $"{this.Namespace}.".StartsWith("System.", StringComparison.Ordinal)
            ? $"[{this.GetReferenceName(useShortName).Escape()}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:{this.MsdnName} '{this.StrippedName}')"
            : $"[{this.GetReferenceName(useShortName).Escape()}](#{this.Href})";

        private string GetReferenceName(bool useShortName) =>
            !useShortName
            ? this.LongName
            : this.Kind == MemberKind.Type
            ? this.TypeShortName
            : this.Kind == MemberKind.Constants ||
              this.Kind == MemberKind.Property ||
              this.Kind == MemberKind.Method
            ? this.FriendlyName
            : this.Kind == MemberKind.Constructor
            ? $"{this.TypeShortName}.{this.FriendlyName}"
            : string.Empty;
    }
}
