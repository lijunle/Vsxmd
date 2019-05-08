//-----------------------------------------------------------------------
// <copyright file="MemberReflector.cs" company="Junle Li">
//     Copyright (c) Junle Li. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Vsxmd.Reflection
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;

    /// <summary>
    /// Reflection helpers for a single <see cref="MemberInfo"/>.
    /// </summary>
    internal abstract class MemberReflector
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MemberReflector"/> class.
        /// </summary>
        /// <param name="member">The member, or null to use default properties.</param>
        public MemberReflector(MemberInfo member)
        {
            try
            {
                this.IsBrowsable = member?.GetCustomAttribute<EditorBrowsableAttribute>()?.State != EditorBrowsableState.Never;
            }
            catch (IOException)
            {
                // Ignore members that are missing dependencies.
                this.IsBrowsable = true;
                Trace.WriteLine($"Warning: unable to use reflection to determine browsable state for {member.DeclaringType}.{member.Name}");
                return;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the member is intended to be discovered outside the assembly.
        /// </summary>
        public bool IsBrowsable { get; }

        /// <summary>
        /// Gets a value indicating whether the member is visible outside of the assembly.
        /// </summary>
        public abstract bool IsVisible { get; }
    }
}
