# FFXINavMeshes

These NavMeshes were built using FFXINAV.dll, a wrapper i wrote for RecastDetour

# Thanks to Vulture for his Map Collision extraction tool, Devi Ltti for fixes and FFXI Zone dat locations.

# FFXINAV.dll function
- unload
- Initialize
- GetLogMessage

- findPath(position_t start, position_t end , false); //Set false if using meshes made with the obj files exported by pathfinder.exe or using dsp.nav files. set true if using meshes made with noesis obj files.

- isNavMeshEnabled
- Pathpoints
- Get_WayPoints
- ReleaseItems
- NavMeshSettings
- DumpNavMesh
when dumping NavMeshes good settings to use are ( cell size 20, height 10, Agent height 1.8, agent radius 0.4, max climb 0.7, and max slope of 47, tile size 48 - but you can lower this for small zones) -- good site to read for NavMesh settings http://digestingduck.blogspot.com/2009/08/recast-settings-uncovered.html


- DLL errors will be saved to FFXINAV_LOG txt file. if you have any problems please check there.

FFXINAV.DLL will also work with DSP NavMeshes 

you can find recast detour here https://github.com/recastnavigation/recastnavigation

 Q: How do I edit the navmesh that was built with FFXINAV.dll in RecastDemo.exe?
 
    A: 1. Place the zone.obj file in  RecastDemo/Meshes/
       2. Place the navmesh.nav in the same folder as RecastDemo.exe "RecastDemo"
       3. Rename "navmesh.nav" to "all_tiles_navmesh.bin"
       4. open RecastDemo.exe-> on the right hand side click -> choose sample -> Tile Mesh
          Input Mesh -> select the .obj file you want to edit.
       5. once the .obj is loaded on screen -> scroll down and click load. you will see the mesh load on screen as "blue"
       6. to remove tiles, on the left hand side click "Create Tiles" then on the mesh click Shift+ left mouse button.
       7. to rebuild the tile click on the part of the mesh with left mouse button.
       8. you can create off-mesh links with the tool on the left hand side. 
       9. when you are finished click save from the tool menu on the right hand side.
       10.It will save as "all_tiles_navmesh.bin" you will need to rename this to "ZoneID.nav".
