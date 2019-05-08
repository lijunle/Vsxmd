//-----------------------------------------------------------------------
// <copyright file="AssemblyReflector.cs" company="Junle Li">
//     Copyright (c) Junle Li. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Vsxmd.Reflection
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Reflection;

    /// <summary>
    /// Reflection helpers for an <see cref="Assembly"/>.
    /// </summary>
    internal class AssemblyReflector
    {
        private readonly Assembly assembly;
        private readonly Dictionary<string, TypeReflector> typeCache;

        /// <summary>
        /// Initializes a new instance of the <see cref="AssemblyReflector"/> class.
        /// </summary>
        /// <param name="assembly">The assembly, or null to disable reflection.</param>
        internal AssemblyReflector(Assembly assembly)
        {
            if (assembly != null)
            {
                this.assembly = assembly;
                this.typeCache = new Dictionary<string, TypeReflector>();
            }
        }

        /// <summary>
        /// Gets a type from the assembly.
        /// </summary>
        /// <param name="name">The name of the type.</param>
        /// <returns>The type.</returns>
        public TypeReflector GetType(string name)
        {
            return this.GetType(name, null);
        }

        /// <summary>
        /// Gets a type from the assembly.
        /// </summary>
        /// <param name="name">The name of the type.</param>
        /// <param name="parent">The parent type if <paramref name="name"/> refers to a nested type.</param>
        /// <returns>The type.</returns>
        private TypeReflector GetType(string name, TypeReflector parent)
        {
            if (this.assembly == null || string.IsNullOrWhiteSpace(name))
            {
                return null;
            }

            if (!this.typeCache.TryGetValue(name, out TypeReflector type))
            {
                var realType = this.assembly.GetType(name, throwOnError: false);

                if (realType == null)
                {
                    // Determine if this is a nested type (which really have a + instead of . in the name).
                    var lastDotIndex = name.LastIndexOf('.');
                    var parentTypeName = name.Substring(0, lastDotIndex);
                    var parentType = this.GetType(parentTypeName);

                    if (parentType != null)
                    {
                        var nestedName = parentType.FullName + "+" + name.Substring(lastDotIndex + 1);
                        var nestedType = this.GetType(nestedName, parentType);

                        if (nestedType != null)
                        {
                            this.typeCache[name] = nestedType;
                            return nestedType;
                        }
                    }

                    Trace.WriteLine($"Warning: unable to use reflection to load type {name}");
                    this.typeCache[name] = null;
                    return null;
                }

                type = new TypeReflector(realType, parent);
                this.typeCache[name] = type;
            }

            return type;
        }
    }
}
