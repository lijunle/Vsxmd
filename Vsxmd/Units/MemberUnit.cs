//-----------------------------------------------------------------------
// <copyright file="MemberUnit.cs" company="Junle Li">
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
    /// Member unit.
    /// </summary>
    internal class MemberUnit : BaseUnit
    {
        private readonly char type;

        static MemberUnit()
        {
            Comparer = new MemberUnitComparer();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MemberUnit"/> class.
        /// </summary>
        /// <param name="element">The member XML element.</param>
        /// <exception cref="ArgumentException">Throw if XML element name is not <c>member</c>.</exception>
        public MemberUnit(XElement element)
            : base(element, "member")
        {
            this.type = this.GetAttribute("name").First();
        }

        /// <summary>
        /// Gets the member unit comparer.
        /// </summary>
        /// <value>The member unit comparer.</value>
        public static IComparer<MemberUnit> Comparer { get; }

        /// <summary>
        /// Gets the type name.
        /// </summary>
        /// <value>The the type name.</value>
        /// <example><c>Vsxmd.Program</c>, <c>Vsxmd.Units.TypeUnit</c>.</example>
        public string TypeName => $"{this.NamespaceName}.{this.TypeShortName}";

        /// <summary>
        /// Gets the member kind, one of <see cref="MemberKind"/>.
        /// </summary>
        /// <value>The member kind.</value>
        public MemberKind Kind =>
            this.type == 'T'
            ? MemberKind.Type
            : this.type == 'F'
            ? MemberKind.Constants
            : this.type == 'P'
            ? MemberKind.Property
            : this.type == 'M' && this.Name.Contains(".#ctor")
            ? MemberKind.Constructor
            : this.type == 'M' && !this.Name.Contains(".#ctor")
            ? MemberKind.Method
            : MemberKind.NotSupported;

        private string TypeShortName =>
            this.Kind == MemberKind.Type
            ? this.NameSegments.Last()
            : this.Kind == MemberKind.Constants ||
              this.Kind == MemberKind.Property ||
              this.Kind == MemberKind.Constructor ||
              this.Kind == MemberKind.Method
            ? this.NameSegments.NthLast(2)
            : string.Empty;

        private string NamespaceName =>
            this.Kind == MemberKind.Type
            ? this.NameSegments.TakeAllButLast(1).Join(".")
            : this.Kind == MemberKind.Constants ||
              this.Kind == MemberKind.Property ||
              this.Kind == MemberKind.Constructor ||
              this.Kind == MemberKind.Method
            ? this.NameSegments.TakeAllButLast(2).Join(".")
            : string.Empty;

        private string Name => this.GetAttribute("name").Substring(2);

        private IEnumerable<string> NameSegments => this.Name.ToNameSegments();

        private string Caption =>
            this.Kind == MemberKind.Type
            ? $"## {this.TypeShortName}"
            : this.Kind == MemberKind.Constants ||
              this.Kind == MemberKind.Property ||
              this.Kind == MemberKind.Constructor ||
              this.Kind == MemberKind.Method
            ? $"### {this.NameSegments.Last().Escape()} `{this.Kind.ToLowerString()}`"
            : string.Empty;

        private IEnumerable<string> InheritDoc =>
            this.GetChild("inheritdoc") == null
                ? Enumerable.Empty<string>()
                : new[]
                {
                    "##### Summary",
                    "*Inherit from parent.*"
                };

        private IEnumerable<string> Namespace =>
            this.Kind != MemberKind.Type
            ? Enumerable.Empty<string>()
            : new[]
            {
                $"##### Namespace",
                $"{this.NamespaceName}"
            };

        private IEnumerable<string> Summary =>
            SummaryUnit.ToMarkdown(this.GetChild("summary"));

        private IEnumerable<string> Returns =>
            ReturnsUnit.ToMarkdown(this.GetChild("returns"));

        private IEnumerable<string> Params =>
            ParamUnit.ToMarkdown(
                this.GetChildren("param"),
                this.ParamTypes,
                this.Kind);

        private IEnumerable<string> ParamTypes =>
            this.Name.GetParamTypes();

        private IEnumerable<string> Typeparams =>
            TypeparamUnit.ToMarkdown(this.GetChildren("typeparam"));

        private IEnumerable<string> Exceptions =>
            ExceptionUnit.ToMarkdown(this.GetChildren("exception"));

        private IEnumerable<string> Permissions =>
            PermissionUnit.ToMarkdown(this.GetChildren("permission"));

        private IEnumerable<string> Example =>
            ExampleUnit.ToMarkdown(this.GetChild("example"));

        private IEnumerable<string> Remarks =>
            RemarksUnit.ToMarkdown(this.GetChild("remarks"));

        private IEnumerable<string> Seealsos =>
            SeealsoUnit.ToMarkdown(this.GetChildren("seealso"));

        /// <inheritdoc />
        public override IEnumerable<string> ToMarkdown() =>
            new[] { this.Caption }
                .Concat(this.Namespace)
                .Concat(this.InheritDoc)
                .Concat(this.Summary)
                .Concat(this.Returns)
                .Concat(this.Params)
                .Concat(this.Typeparams)
                .Concat(this.Exceptions)
                .Concat(this.Permissions)
                .Concat(this.Example)
                .Concat(this.Remarks)
                .Concat(this.Seealsos);

        /// <summary>
        /// Complement a type unit if the member unit <paramref name="group"/> does not have one.
        /// One member unit group has the same <see cref="TypeName"/>.
        /// </summary>
        /// <param name="group">The member unit group.</param>
        /// <returns>The complemented member unit group.</returns>
        internal static IEnumerable<MemberUnit> ComplementType(
            IEnumerable<MemberUnit> group) =>
            group.Any(unit => unit.Kind == MemberKind.Type)
                ? group
                : group.Concat(new[] { Create(group.First().TypeName) });

        private static MemberUnit Create(string typeName) =>
            new MemberUnit(
                new XElement("member",
                    new XAttribute("name", $"T:{typeName}")));

        private class MemberUnitComparer : IComparer<MemberUnit>
        {
            /// <inheritdoc />
            public int Compare(MemberUnit x, MemberUnit y) =>
                x.TypeShortName != y.TypeShortName
                ? x.TypeShortName.CompareTo(y.TypeShortName)
                : x.Kind != y.Kind
                ? x.Kind.CompareTo(y.Kind)
                : x.Name.CompareTo(y.Name);
        }
    }
}
