# FFXINavMeshes


These NavMeshes were built using FFXINAV.dll, a wrapper i wrote for RecastDetour

Thanks to Vulture for his Map Collision extraction too, Devi Ltti for fixes and FFXI Zone dat locations.


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
