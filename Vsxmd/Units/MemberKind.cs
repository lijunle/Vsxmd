//-----------------------------------------------------------------------
// <copyright file="MemberKind.cs" company="Junle Li">
//     Copyright (c) Junle Li. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Vsxmd.Units
{
    /// <summary>
    /// The member kind.
    /// </summary>
    internal enum MemberKind
    {
        /// <summary>
        /// Not supported member kind.
        /// </summary>
        NotSupported,

        /// <summary>
        /// Type.
        /// </summary>
        Type,

        /// <summary>
        /// Constructor.
        /// </summary>
        Constructor,

        /// <summary>
        /// Constants
        /// </summary>
        Constants,

        /// <summary>
        /// Property.
        /// </summary>
        Property,

        /// <summary>
        /// Method.
        /// </summary>
        Method,
    }
}
