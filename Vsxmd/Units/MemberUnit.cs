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
        private const char T = 'T';

        private const char F = 'F';

        private const char P = 'P';

        private const char M = 'M';

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
            this.type = this.Element.Attribute("name").Value.First();
        }

        /// <summary>
        /// Gets the member unit comparer.
        /// </summary>
        /// <value>The member unit comparer.</value>
        public static IComparer<MemberUnit> Comparer { get; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The member name</value>
        /// <example><c>Vsxmd.Units.TypeUnit</c>, <c>Vsxmd.Units.TypeUnit.#ctor(System.Xml.Linq.XElement)</c>, <c>Vsxmd.Units.TypeUnit.TypeName</c>.</example>
        public string Name => this.Element.Attribute("name").Value.Substring(2);

        /// <summary>
        /// Gets the type full name.
        /// </summary>
        /// <value>The the type full name.</value>
        /// <example><c>Vsxmd.Program</c>, <c>Vsxmd.Units.TypeUnit</c>.</example>
        public string TypeFullName => $"{this.NamespaceName}.{this.TypeName}";

        /// <summary>
        /// Gets the member kind, one of <see cref="MemberKind"/>.
        /// </summary>
        /// <value>The member kind.</value>
        public MemberKind Kind
        {
            get
            {
                switch (this.type)
                {
                    case T:
                        return MemberKind.Type;
                    case F:
                        return MemberKind.Constants;
                    case P:
                        return MemberKind.Property;
                    case M:
                        return this.Name.Contains(".#ctor")
                            ? MemberKind.Constructor
                            : MemberKind.Method;
                    default:
                        return MemberKind.NotSupported;
                }
            }
        }

        /// <summary>
        /// Gets the type name.
        /// </summary>
        /// <value>The type name.</value>
        /// <example><c>Program</c>, <c>Converter</c>.</example>
        public string TypeName
        {
            get
            {
                switch (this.type)
                {
                    case T:
                        return this.Name.Split('.').Last();
                    case F:
                    case P:
                    case M:
                        return this.NameSegments.NthLastOrDefault(1);
                    default:
                        return string.Empty;
                }
            }
        }

        /// <summary>
        /// Gets the namespace name.
        /// </summary>
        /// <value>The namespace name.</value>
        /// <example><c>Vsxmd</c>, <c>Vsxmd.Units</c>.</example>
        public string NamespaceName
        {
            get
            {
                switch (this.type)
                {
                    case T:
                        return this.Name.Substring(0, this.Name.Length - this.TypeName.Length - 1);
                    case F:
                    case P:
                    case M:
                        return this.NameSegments.TakeAllButLast(2).Join(".");
                    default:
                        return string.Empty;
                }
            }
        }

        private string KindString => this.Kind.ToString().ToLower();

        private IEnumerable<string> NameSegments =>
            this.Name.Split('(').First().Split('.');

        private IEnumerable<string> InheritDoc =>
            this.Element.Element("inheritdoc") != null
                ? new[] { "Inherit documentation from parent." }
                : Enumerable.Empty<string>();

        private IEnumerable<string> Summary =>
            SummaryUnit.ToMarkdown(this.Element.Element("summary"));

        private IEnumerable<string> Returns =>
            ReturnsUnit.ToMarkdown(this.Element.Element("returns"));

        private IEnumerable<string> Params =>
            ParamUnit.ToMarkdown(this.Element.Elements("param"), this.ParamTypes);

        private IEnumerable<string> ParamTypes =>
            this.Name.Split('(').Last().Trim(')').Split(',');

        private IEnumerable<string> Typeparams =>
            TypeparamUnit.ToMarkdown(this.Element.Elements("typeparam"));

        private IEnumerable<string> Exceptions =>
            ExceptionUnit.ToMarkdown(this.Element.Elements("exception"));

        private IEnumerable<string> Permissions =>
            PermissionUnit.ToMarkdown(this.Element.Elements("permission"));

        private IEnumerable<string> Example =>
            ExampleUnit.ToMarkdown(this.Element.Element("example"));

        private IEnumerable<string> Remarks =>
            RemarksUnit.ToMarkdown(this.Element.Element("remarks"));

        /// <inheritdoc />
        public override IEnumerable<string> ToMarkdown()
        {
            switch (this.type)
            {
                case T:
                    return new[]
                    {
                        $"## {this.TypeName}",
                        $"##### Namespace",
                        $"{this.NamespaceName}"
                    }
                    .Concat(this.InheritDoc)
                    .Concat(this.Summary)
                    .Concat(this.Permissions)
                    .Concat(this.Remarks);
                case F:
                case P:
                case M:
                    return new[]
                    {
                        $"### {this.NameSegments.Last().Escape()} `{this.KindString}`"
                    }
                    .Concat(this.InheritDoc)
                    .Concat(this.Summary)
                    .Concat(this.Returns)
                    .Concat(this.Params)
                    .Concat(this.Typeparams)
                    .Concat(this.Exceptions)
                    .Concat(this.Permissions)
                    .Concat(this.Example)
                    .Concat(this.Remarks);
                default:
                    return Enumerable.Empty<string>();
            }
        }

        private class MemberUnitComparer : IComparer<MemberUnit>
        {
            /// <inheritdoc />
            public int Compare(MemberUnit x, MemberUnit y)
            {
                if (x.TypeName != y.TypeName)
                {
                    return x.TypeName.CompareTo(y.TypeName);
                }
                else if (x.Kind != y.Kind)
                {
                    return x.Kind.CompareTo(y.Kind);
                }
                else
                {
                    return x.Name.CompareTo(y.Name);
                }
            }
        }
    }
}
