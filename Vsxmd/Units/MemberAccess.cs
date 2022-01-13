//-----------------------------------------------------------------------
// <copyright file="MemberAccess.cs" company="Junle Li">
//     Copyright (c) Junle Li. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Vsxmd.Units
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using Vsxmd.Reflection;

    /// <summary>
    /// Member access scope.
    /// </summary>
    internal class MemberAccess
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MemberAccess"/> class.
        /// </summary>
        /// <param name="name">The member name.</param>
        /// <param name="assembly">The assembly owning the member, or null if not known.</param>
        internal MemberAccess(MemberName name, AssemblyReflector assembly)
        {
            this.IsVisible = true;
            this.IsBrowsable = true;
            var type = assembly.GetType(name.TypeName);

            if (type == null)
            {
                return;
            }

            this.IsVisible = type.IsVisible;
            this.IsBrowsable = type.IsBrowsable;

            MemberReflector member = null;

            switch (name.Kind)
            {
                case MemberKind.Constants:
                    member = type.GetField(name.FriendlyName);
                    break;
                case MemberKind.Constructor:
                    member = SelectMatchingMethod(name, type.Constructors);
                    break;
                case MemberKind.Property:
                    member = type.GetProperty(name.FriendlyName);
                    break;
                case MemberKind.Method:
                    member = SelectMatchingMethod(name, type.GetMethods(name.FriendlyName));
                    break;

                // Includes MemberKind.Type
                default:
                    return;
            }

            if (member != null)
            {
                this.IsVisible &= member.IsVisible;
                this.IsBrowsable &= member.IsBrowsable;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the type is intended to be discovered outside the assembly.
        /// </summary>
        internal bool IsBrowsable { get; }

        /// <summary>
        /// Gets a value indicating whether the member is visible outside of the assembly.
        /// </summary>
        internal bool IsVisible { get; }

        private static MethodReflector SelectMatchingMethod(MemberName name, IEnumerable<MethodReflector> methods)
        {
            // This algorithm can be improved if we want to parse type arguments.
            // Currently, it strips away all generic type arguments.
            var paramTypes = name.GetParamTypes().ToList();

            foreach (var method in methods)
            {
                int i;
                var parameters = method.Parameters;

                if (paramTypes.Count != parameters?.Length)
                {
                    continue;
                }

                for (i = 0; i < parameters.Length; i++)
                {
                    Type parameterType;
                    string parameterName;
                    bool hasArray = false;
                    Type originalParameterType = parameters[i].ParameterType;
                    Type elementType = originalParameterType;

                    do
                    {
                        hasArray |= elementType.IsArray;
                        parameterType = elementType;
                        elementType = parameterType.GetElementType();
                    }
                    while (elementType != null);

                    if (parameterType.IsGenericParameter)
                    {
                        parameterName = "`" + parameterType.GenericParameterPosition;
                    }
                    else
                    {
                        parameterName = parameterType.FullName?.Split('`')[0];
                    }

                    if (hasArray)
                    {
                        parameterName += "[]";
                    }

                    if (originalParameterType.IsByRef)
                    {
                        parameterName += "@";
                    }

                    var docParameterName = paramTypes[i].Substring(2);
                    var genericBracketIndex = docParameterName.IndexOf('{', StringComparison.Ordinal);
                    var endGenericIndex = docParameterName.LastIndexOf('}');
                    if (genericBracketIndex > 0 && endGenericIndex > genericBracketIndex)
                    {
                        docParameterName = docParameterName.Substring(0, genericBracketIndex) + docParameterName.Substring(endGenericIndex + 1);
                    }

                    // Nested types have a + in the type name but . in the XML.
                    if (parameterName.Replace('+', '.') != docParameterName)
                    {
                        break;
                    }
                }

                if (i == parameters.Length)
                {
                    return method;
                }
            }

            Trace.WriteLine($"Warning: unable to locate method using reflection for {name.TypeName}.{name.FriendlyName}");
            return null;
        }
    }
}
