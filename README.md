######### Optimization size built:
Prefab :
- Make Prefabs in Level reference from Prefab in Asset
- note:
- Some Prefabs be changed when editer or GD set map need to cache infor and clear when build - because when build all prefabs will be split and some prefabs have been changed - will be determine is different prefabs and increasing size build
- Example infor when build done: some level have size build bigger than real size of it.
- Example explain for it https://www.youtube.com/watch?v=4JLpJHIdx7E&t=3s
Texture :
- compress texture to size it draw on scene (should size is multiples of 2 to most optimal)
- note properties of texture when import to unity
- you can use again some texture UI in the similary popup - you need optimize it to use again
- using sprite atlas (when you want to decrease draw call) - you can use tight packing to min size atlas  but need to set up texture with mesh type full rect and sprite component is using sprite mesh (to avoid split texture in atlas be include other texture part in bound)
Model Mesh:
- with Model 3D some object don't move on scene need to tick static batching to down draw call
- model can be compress with quality{no,low,medium,high} - to down size
- some Mesh can be drawed by GPU instance -https://www.youtube.com/watch?v=cwbyvbtJ9UY(GPU Instance use some graphic function to draw some the same mesh => decrease batch render)
- other: Using full rect mesh type of texture can decrease tris of mesh render on scene if use tile map - (if you do not use full rect - tilemap will group all texture mesh => increase tris)
Model Anim:
- Anim is also compress size because properties -
Sound:
- Compress size like example link: https://codethunder978933933.wordpress.com/2020/08/24/toi-uu-audio-asset-trong-unity/
- Other way -> you can random varying the pitch by small amount to reuse one clip instead of using some clip
######## Some note about draw call
- Create sprite Atlas to group all decor texture in level - one draw for all
- if need using heal progress - use only one canvas for all to avoid some dynamic draw
- if using sorting by axis y - avoid group texure

######## Error in Splash Screen:
- splash screen be flickreing after blur - need to add one canvas or cam to empty scene if load scene by addressable
######### Garbage Collection
- Heap and stack...
- Coroutine need to avoid using "new waitforsecond" -  garbage be created
- Boxing is the term for what happens when a value-typed variable is used in place of a reference-typed variable
