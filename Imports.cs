// *********************************************************************** Assembly : PathFinder
// Author : xenonsmurf Created : 04-03-2020 Created : 04-03-2020 Created : 04-03-2020 Created : 04-03-2020
//
// Last Modified By : xenonsmurf Last Modified On : 04-04-2020 Last Modified On : 04-12-2020 ***********************************************************************
// <copyright file="Imports.cs" company="Xenonsmurf">
//     Copyright © 2020
// </copyright>
// <summary>
// </summary>
// ***********************************************************************
using Microsoft.Win32.SafeHandles;
using System;
using System.Runtime.InteropServices;

namespace PathFinder.Common
{
    /// <summary>
    /// Class FFXINAV.
    /// </summary>
    public partial class FFXINAV
    {
        /// <summary>
        /// The old string
        /// </summary>
        private string oldString = string.Empty;

        /// <summary>
        /// Unloads this instance.
        /// </summary>
        [DllImport("FFXINAV.dll", EntryPoint = "unload", CallingConvention = CallingConvention.Cdecl)]
        public static extern void unload();

        /// <summary>
        /// Initializes the specified pathsize.
        /// </summary>
        /// <param name="pathsize">The pathsize.</param>
        [DllImport("FFXINAV.dll", EntryPoint = "Initialize", CallingConvention = CallingConvention.Cdecl)]
        public static extern void initialize(int pathsize);

        /// <summary>
        /// Loads the specified path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("FFXINAV.dll", EntryPoint = "load", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern bool load(string path);

        [DllImport("FFXINAV.dll", EntryPoint = "LoadOBJFile", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern bool LoadOBJFile(string path);

        [DllImport("FFXINAV.dll", EntryPoint = "DumpNavMesh", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern bool DumpNavMesh(string path);

        /// <summary>
        /// Gets the error message.
        /// </summary>
        /// <returns>System.String.</returns>
        [DllImport("FFXINAV.dll", EntryPoint = "GetLogMessage", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.LPStr)]
        public static extern string getLogMessage();

        /// <summary>
        /// Finds the path to posi.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <param name="UseCustomNavMesh">if set to <c>true</c> [use custom nav mesh].</param>
        [DllImport("FFXINAV.dll", EntryPoint = "FindPath", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.LPStr)]
        public static extern void findPath(position_t start, position_t end, bool UseCustomNavMesh);

        /// <summary>
        /// Determines whether [is nav mesh enabled].
        /// </summary>
        /// <returns><c>true</c> if [is nav mesh enabled]; otherwise, <c>false</c>.</returns>
        [DllImport("FFXINAV.dll", EntryPoint = "isNavMeshEnabled", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern bool isNavMeshEnabled();

        /// <summary>
        /// Pathpointses this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        [DllImport("FFXINAV.dll", EntryPoint = "Pathpoints", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern int pathpoints();

        [DllImport("FFXINAV.dll", EntryPoint = "NavMeshSettings", CallingConvention = CallingConvention.Cdecl)]
        public static extern void navMeshSettings(double CellSize, double CellHeight, double AgentHight, double AgentRadius, double MaxClimb,
         double MaxSlope, double TileSize);

        /// <summary>
        /// Gets the m points x.
        /// </summary>
        /// <param name="itemsHandle">The items handle.</param>
        /// <param name="itemsHandle2">The items handle2.</param>
        /// <param name="xitems">The xitems.</param>
        /// <param name="zitems">The zitems.</param>
        /// <param name="itemCount">The item count.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("FFXINAV.dll", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe bool Get_WayPoints(out ItemsSafeHandle itemsHandle, out ItemsSafeHandle itemsHandle2,
            out double* xitems, out double* zitems, out int itemCount);

        /// <summary>
        /// Releases the items.
        /// </summary>
        /// <param name="itemsHandle">The items handle.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("FFXINAV.dll", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern bool ReleaseItems(IntPtr itemsHandle);

        /// <summary>
        /// Gets the m points x wrapper.
        /// </summary>
        /// <param name="xitems">The xitems.</param>
        /// <param name="zitems">The zitems.</param>
        /// <param name="itemsCount">The items count.</param>
        /// <returns>ItemsSafeHandle.</returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static unsafe ItemsSafeHandle Get_WayPoints_Wrapper(out double* xitems, out double* zitems, out int itemsCount)
        {
            ItemsSafeHandle itemsHandle;
            if (!Get_WayPoints(out itemsHandle, out ItemsSafeHandle itemsHandle2, out xitems, out zitems, out itemsCount))
            {
                throw new InvalidOperationException();
            }
            return itemsHandle;
        }

        /// <summary>
        /// Class ItemsSafeHandle. Implements the <see cref="Microsoft.Win32.SafeHandles.SafeHandleZeroOrMinusOneIsInvalid"/>
        /// </summary>
        /// <seealso cref="Microsoft.Win32.SafeHandles.SafeHandleZeroOrMinusOneIsInvalid"/>
        public class ItemsSafeHandle : SafeHandleZeroOrMinusOneIsInvalid
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="ItemsSafeHandle"/> class.
            /// </summary>
            public ItemsSafeHandle()
                : base(true)
            {
            }

            /// <summary>
            /// When overridden in a derived class, executes the code required to free the handle.
            /// </summary>
            /// <returns>
            /// <see langword="true"/> if the handle is released successfully; otherwise, in the
            /// event of a catastrophic failure, <see langword=" false"/>. In this case, it
            /// generates a releaseHandleFailed MDA Managed Debugging Assistant.
            /// </returns>
            protected override bool ReleaseHandle()
            {
                return ReleaseItems(handle);
            }
        }
    }
}