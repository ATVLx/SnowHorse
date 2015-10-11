====================================
=  PDG Snowy Mountain Terrain v1.0 =
====================================

Thank you for purchasing this asset - I hope you enjoy it as much as I did, creating it!

Please note: 

- If you need more tiling terrain-patches matching this style
- If you need any other custom made terrains or maps
- If you looking for someone to bring your terrain/landscapes to Unity3D
- If you implemented this asset into your project 

...just let me know!


Drop an e-mail to: unity@play-da-gaimz.de


******************
*CONTENT-OVERVIEW*
******************

This asset features:

Tiling terrains/meshes
----------------------
16x 2049x2049.raw 16-bit heightfields to create Unity terrains from
16x 2048x2048.png normal maps, matching the unity tangent space
16x 2048x2048.png PBR-ready Textures for Unity5 Standard Shader, with detail mask
16x 2048x2048.png Splat maps (RGBA) R=snowy lower areas G=steep Rock areas B=Snow on mountains A='flow lines' / erosion path
1x  1024x1024.png Detail Albedo map
1x  1024x1024.png Detail Normal map
16x low poly meshes (around 3k tris) in .OBJ format, center=origin, Y=up orientation


Single terrain/mesh/textures 'BIG_Mountain'
---------------------------------------
1x 2049x2049.raw 16-bit heightfield, covering all 16-tiles at once
1x 2048x2048.png normal map, matching the unity tangent space
1x 2048x2048.png PBR-ready Textures for Unity5 Standard Terrain-Shader
1x 2048x2048.png Splat maps (RGBA) R=snowy lower areas G=steep Rock areas B=Snow on mountain-top A='flow lines' / erosion path 

1x low poly mesh (around 5k tris) in .OBJ format, center=origin
1x low poly mesh (around 10k tris) in .OBJ format, center=origin
1x low poly mesh (around 30k tris) in .OBJ format, center=origin


Additional goodies
------------------
1x Unity scene 'Meshes' (hosts an example of tiling meshes)
1x Unity scene 'Terrains' (hosts an example of tiling terrains)
1x Unity scene 'Big_Mountain' (hosts an example of '1-patch cover it all' terrains)

1x 'TerrainSticher' Javascript for making unity-terrain LOD seamless at runtime (At runtime!)

7x tiling detail color map textures '_BC' for painting or use with splat maps
7x tiling detail normal map textures'_NO' for painting or use with splat maps
6x 2048x2048.png Skybox textures



Some technical information
--------------------------

- Remember to set the textures (except for detail textures and splat maps) to 'clamp` instead of ´repeat´ 
  to get a 100% smooth and seamless tiling for meshes, terrains and skybox

- Textures look best when set to '2048' and 'Truecolor' in the inspector window

- Textures with '_TN' are normal maps, other textures are:

Mountain_Mesh_ALB-DET... for use with the meshes in Standard Shader's 'Albedo' and 'Detail Mask' slot. Holds color information in (RGB) and a detail mask in (A)
Mountain_Mesh_MET-SMO... for use with the meshes in Standard Shader's 'Metallic' slot. Contains PBR metal information (RGB) and smoothness in (A)
Mountain_Mesh_AO... for use with the meshes in Standard Shader's 'Occlusion' slot. Contains Ambient Occlusion information (RGB)
Mountain_Terrain_ALB-SMO... for use with the terrains in Standard Terrain Shader. Holds color information in (RGB) and smoothness in (A)
'Detail_Rock_BC.png' and 'Detail_Rock_BC_snow.png'   ... for use with the meshes in Standard Shader's 'Secondary Maps - Detail Albedo x2' slot
'Detail_NO.png' ... for use with the meshes in Standard Shader's 'Secondary Maps - Detail Normal Map' slot

- Good scaling factors for the .raw files are X=2000X Y=700 Z=2000, byte-order is 'Windows'

- Splat maps must be set to ARGB 32-bit, read/write enabled

- If you're using Marmoset Skyshop´s 'Terrain->Import Splat map' script, keep 'Flip-Y Axis' checked, when importing splat maps

- To make terrains LOD´s seamless, use the provided 'TerrainSticher' script.
  Just drag over the script to all your terrain-tiles in hierarchy tree and remember to set neighbour for
  each terrain. Like when telling 'Terrain1', that 'Terrain2' is the left neighbour - you also have to tell
  'Terrain2', that 'Terrain1' is the right neighbour. (See example setup in 'Tiling-Terrains' scene)

- Remember you can set a 'pixel error value' for the terrains (1=ultra quality, 5=lower quality from distance)



Placing tiling terrains
-----------------------

Terrains must be placed in a specific order, to get matching borders:

+----+----+----+----+
+x0y3+x1y3+x2y3+x3y3+
+----+----+----+----+
+x0y2+x1y2+x2y2+x3y2+
+----+----+----+----+
+x0y1+x1y1+x2y1+x3y1+
+----+----+----+----+
+x0y0+x1y0+x2y0+x3y0+
+----+----+----+----+

(see demo scene 'Tiling-Terrains')


TerrainSticher script
---------------------

The script follows the same logic, as the grid above.

Like when applying the script to tile x0y0 and x1y0 for example, you have to assign "terrain tile x1y0" in
the "Terrain right" slot of the script attached to terrain tile x0y0. For terrain tile x1y0, you have
to assign "terrain tile x0y0" as "Terrain left" in the script's slot of terrain x1y0.

Terrain tile x0y1 would be the "Terrain top" - neighbour of tile x0y0 and x0y0 is "Terrain bottom" neighbour
of tile x0y1.

(Again, please see 'Tiling-Terrains' demo scene for example setup)



If you need more information or want to give feedback, please contact: unity@play-da-gaimz.de


For more information and reference, please see:
http://docs.unity3d.com/Documentation/Manual/Terrains.html for reference.
http://docs.unity3d.com/Documentation/Components/terrain-Textures.html


