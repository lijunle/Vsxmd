//-----------------------------------------------------------------------
// <copyright file="PublicApiFilter.cs" company="Junle Li">
//     Copyright (c) Junle Li. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Vsxmd
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// Filter to determine if a member is part of the public API.
    /// </summary>
    internal class PublicApiFilter
    {
        private readonly Assembly assembly;
        private readonly HashSet<string> publicMemberNames;

        /// <summary>
        /// Initializes a new instance of the <see cref="PublicApiFilter"/> class.
        /// </summary>
        /// <param name="assemblyPath">The path to the assembly DLL file.</param>
        public PublicApiFilter(string assemblyPath)
        {
            if (string.IsNullOrWhiteSpace(assemblyPath))
            {
                this.assembly = null;
                this.publicMemberNames = null;
                return;
            }

            try
            {
                this.assembly = Assembly.LoadFrom(assemblyPath);
                this.publicMemberNames = new HashSet<string>();
                this.PopulatePublicMembers();
            }
            catch
            {
                // If we can't load the assembly, don't filter anything
                this.assembly = null;
                this.publicMemberNames = null;
            }
        }

        /// <summary>
        /// Determines whether the specified member name represents a public API member.
        /// </summary>
        /// <param name="memberName">The member name in XML documentation format (e.g., "T:Namespace.Type", "M:Namespace.Type.Method").</param>
        /// <returns><c>true</c> if the member is public or if filtering is disabled; otherwise, <c>false</c>.</returns>
        public bool IsPublicApi(string memberName)
        {
            // If we don't have an assembly loaded, include all members (backwards compatibility)
            if (this.assembly == null || this.publicMemberNames == null)
            {
                return true;
            }

            return this.publicMemberNames.Contains(memberName);
        }

        private void PopulatePublicMembers()
        {
            var types = this.assembly.GetTypes()
                .Where(t => t.IsPublic || t.IsNestedPublic);

            foreach (var type in types)
            {
                // Add the type itself
                this.publicMemberNames.Add($"T:{this.GetTypeName(type)}");

                // Add public constructors
                foreach (var constructor in type.GetConstructors(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static))
                {
                    this.publicMemberNames.Add(this.GetMemberName(constructor));
                }

                // Add public methods
                foreach (var method in type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly))
                {
                    if (!method.IsSpecialName)
                    {
                        this.publicMemberNames.Add(this.GetMemberName(method));
                    }
                }

                // Add public properties
                foreach (var property in type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly))
                {
                    this.publicMemberNames.Add(this.GetMemberName(property));
                }

                // Add public fields (constants)
                foreach (var field in type.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly))
                {
                    this.publicMemberNames.Add(this.GetMemberName(field));
                }
            }
        }

        private string GetTypeName(Type type)
        {
            if (type.IsGenericType)
            {
                var genericArgs = type.GetGenericArguments();
                var typeName = type.FullName.Substring(0, type.FullName.IndexOf('`'));
                return $"{typeName}{{{string.Join(",", genericArgs.Select(this.GetTypeName))}}}";
            }

            return type.FullName?.Replace('+', '.');
        }

        private string GetMemberName(MemberInfo member)
        {
            switch (member)
            {
                case ConstructorInfo constructor:
                    return this.GetConstructorName(constructor);
                case MethodInfo method:
                    return this.GetMethodName(method);
                case PropertyInfo property:
                    return this.GetPropertyName(property);
                case FieldInfo field:
                    return this.GetFieldName(field);
                default:
                    return string.Empty;
            }
        }

        private string GetConstructorName(ConstructorInfo constructor)
        {
            var typeName = this.GetTypeName(constructor.DeclaringType);
            var parameters = constructor.GetParameters();

            if (parameters.Length == 0)
            {
                return $"M:{typeName}.#ctor";
            }

            var paramString = string.Join(",", parameters.Select(p => this.GetParameterTypeName(p.ParameterType)));
            return $"M:{typeName}.#ctor({paramString})";
        }

        private string GetMethodName(MethodInfo method)
        {
            var typeName = this.GetTypeName(method.DeclaringType);
            var methodName = method.Name;

            // Handle generic methods
            if (method.IsGenericMethod)
            {
                methodName += $"``{method.GetGenericArguments().Length}";
            }

            var parameters = method.GetParameters();
            if (parameters.Length == 0)
            {
                return $"M:{typeName}.{methodName}";
            }

            var paramString = string.Join(",", parameters.Select(p => this.GetParameterTypeName(p.ParameterType)));
            return $"M:{typeName}.{methodName}({paramString})";
        }

        private string GetPropertyName(PropertyInfo property)
        {
            var typeName = this.GetTypeName(property.DeclaringType);
            return $"P:{typeName}.{property.Name}";
        }

        private string GetFieldName(FieldInfo field)
        {
            var typeName = this.GetTypeName(field.DeclaringType);
            return $"F:{typeName}.{field.Name}";
        }

        private string GetParameterTypeName(Type type)
        {
            if (type.IsGenericParameter)
            {
                // Generic method parameter
                if (type.DeclaringMethod != null)
                {
                    return $"``{type.GenericParameterPosition}";
                }

                // Generic type parameter
                return $"`{type.GenericParameterPosition}";
            }

            if (type.IsGenericType)
            {
                var genericArgs = type.GetGenericArguments();
                var typeName = type.FullName?.Substring(0, type.FullName.IndexOf('`')) ?? type.Name.Substring(0, type.Name.IndexOf('`'));
                var ns = type.Namespace;
                var fullTypeName = ns != null ? $"{ns}.{typeName}" : typeName;
                return $"{fullTypeName}{{{string.Join(",", genericArgs.Select(this.GetParameterTypeName))}}}";
            }

            if (type.IsArray)
            {
                return $"{this.GetParameterTypeName(type.GetElementType())}[]";
            }

            return type.FullName?.Replace('+', '.') ?? type.Name;
        }
    }
}
