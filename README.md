# FFXINavMeshes


These NavMeshes were built using FFXINAV.dll. 
ffxinav.dll is a custom wrapper i am working on to work with FFXI, this dll uses Recast Detour.

I have included the imports.cs and ffxinavtools.cs files to use FFXINAV.dll in c#

### Special Thanks!
* Vulture for his Map Collision extraction tool
* Devi Ltti for fixes to the extraction tool and FFXI Zone dat locations.

### Features

* CanSeeDestination 
* Unload
* Initialize //pathsize doesn't matter
* Load
* LoadOBJFile
* DumpNavMesh
* GetLogMessage
* FindPath  
* GetDistanceToWall //this is distance to navmesh edge
* GetRotation 
* IsNavMeshEnabled
* PathPoints
* NavMeshSettings //Lets you change the NavMesh settings before building a new mesh
* GetWaypoints    //returns the waypoints in the path 

### navmesh settings all meshes are dumped with.


    float m_tileSize = 64;         <<<< this can be changed for small zones.
	float m_cellSize = 0.15f;
	float m_cellHeight = 0.075f;
	float m_agentHeight = 1.8f;    
	float m_agentRadius = 0.7f;     <<<< if you make this too big it will break the mesh. 0.7f has been tested on most zones.
	float m_agentMaxClimb = 0.5f;   <<<< this might need changing for some zones. max climb changes from 0.3f to 0.5f, trial and error
	float m_agentMaxSlope = 46.0f;
	float m_regionMinSize = 8;
	float m_regionMergeSize = 20;
	float m_edgeMaxLen = 12.0f;
	float m_edgeMaxError = 1.3f;
	float m_vertsPerPoly = 6.0f;
	float m_detailSampleDist = 6.0f;
	float m_detailSampleMaxError = 1.0f;
	
	



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
