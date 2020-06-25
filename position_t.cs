// *********************************************************************** Assembly : PathFinder
// Author : xenonsmurf Created : 03-16-2020 Created : 03-16-2020 Created : 03-16-2020 Created : 03-16-2020
//
// Last Modified By : xenonsmurf Last Modified On : 03-23-2020 Last Modified On : 04-12-2020 ***********************************************************************
// <copyright file="position_t.cs" company="Xenonsmurf">
//     Copyright © 2020
// </copyright>
// <summary>
// </summary>
// ***********************************************************************
using System;

namespace PathFinder.Common
{
    /// <summary>
    /// Struct position_t
    /// </summary>
    public struct position_t
    {
        /// <summary>
        /// The x
        /// </summary>
        public float X;

        /// <summary>
        /// The y
        /// </summary>
        public float Y;

        /// <summary>
        /// The z
        /// </summary>
        public float Z;

        /// <summary>
        /// The moving
        /// </summary>
        public UInt16 Moving;

        /// <summary>
        /// The rotation
        /// </summary>
        public sbyte Rotation;
    }
}