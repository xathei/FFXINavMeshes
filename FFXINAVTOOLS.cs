// *********************************************************************** Assembly : PathFinder
// Author : xenonsmurf Created : 04-03-2020 Created : 04-03-2020 Created : 04-03-2020 Created : 04-03-2020
//
// Last Modified By : xenonsmurf Last Modified On : 04-04-2020 Last Modified On : 04-12-2020 ***********************************************************************
// <copyright file="FFXINAVTOOLS.cs" company="Xenonsmurf">
//     Copyright © 2020
// </copyright>
// <summary>
// </summary>
// ***********************************************************************
using PathFinder.Characters;
using System;
using System.Collections.Generic;
using System.Threading;

namespace PathFinder.Common
{
    /// <summary>
    /// Class FFXINAV.
    /// </summary>
    public partial class FFXINAV
    {
        /// <summary>
        /// Gets or sets the waypoints.
        /// </summary>
        /// <value>The waypoints.</value>
        public List<position_t> Waypoints { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FFXINAV"/> class.
        /// </summary>
        public FFXINAV()
        {
            Waypoints = new List<position_t>();
        }

        /// <summary>
        /// Unloads this instance.
        /// </summary>
        public void Unload()
        {
            unload();
        }

        /// <summary>
        /// Initializes the specified pathsize.
        /// </summary>
        /// <param name="pathsize">The pathsize.</param>
        public void Initialize(int pathsize)
        {
            initialize(pathsize);
        }

        /// <summary>
        /// Loads the specified file.
        /// </summary>
        /// <param name="file">The file.</param>
        public void Load(string file)
        {
            load(file);
        }

        public void LoadOBJfile(string file)
        {
            Initialize(100);
            Thread.Sleep(2000);
            LoadOBJFile(file);
        }

      public   bool DumpingMesh { get; set; } = false;
        public void Dump_NavMesh(string file)
        {
            if (DumpingMesh == false)
            {
                DumpingMesh = true;
                LoadOBJFile(file);
                DumpNavMesh(file);
                DumpingMesh = false;
            }
        }

        /// <summary>
        /// Gets the error message.
        /// </summary>
        /// <returns>System.String.</returns>
        public string GetErrorMessage()
        {
            return getLogMessage().ToString();
        }

        /// <summary>
        /// Finds the path to posi.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <param name="UseCustonNavMeshes">if set to <c>true</c> [use custon nav meshes].</param>
        public void FindPathToPosi(position_t start, position_t end, bool UseCustonNavMeshes)
        {
            //set false if using DSP Nav files
            //set true if using Meshes made with Noesis map data
            findPath(start, end, UseCustonNavMeshes);
        }

        /// <summary>
        /// Determines whether [is nav mesh enabled].
        /// </summary>
        /// <returns><c>true</c> if [is nav mesh enabled]; otherwise, <c>false</c>.</returns>
        public bool IsNavMeshEnabled()
        {
            return isNavMeshEnabled();
        }

        /// <summary>
        /// Pathes the count.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int PathCount()
        {
            return pathpoints();
        }

        /// <summary>
        /// Gets the waypoints.
        /// </summary>
        public unsafe void GetWaypoints()
        {
            Waypoints.Clear();
            if (pathpoints() > 0)
            {
                double* xitems;
                double* zitems;
                int itemsCount;

                using (FFXINAV.Get_WayPoints_Wrapper(out xitems, out zitems, out itemsCount))
                {
                    for (int i = 0; i < itemsCount; i++)
                    {
                        var position = new position_t { X = (float)xitems[i], Z = (float)zitems[i] };
                        Waypoints.Add(position);
                    }
                }
            }
        }

        public void ChangeNavMeshSettings(double CellSize, double CellHeight, double AgentHeight, double AgentRadius, double MaxClimb,
         double MaxSlope, double TileSize)
        {
            navMeshSettings(CellSize, CellHeight, AgentHeight, AgentRadius, MaxClimb, MaxSlope, TileSize);
        }

        /// <summary>
        /// Converts to single.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.Single.</returns>
        public static float ToSingle(double value)
        {
            return (float)value;
        }
    }
}