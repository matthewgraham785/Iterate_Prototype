# ITERATE

I'm building ITERATE as an eight-week solo Unity 3D platformer. I use this repository to show my progress, share my code, and explain how the project develops as I learn.

## What I'm building

I'm presenting the level as a machine-learning training environment. The player chooses between an easier route and a more difficult route, and those routes eventually merge. My longer-term goal is to track player behavior and use it to adapt a later run. Behavior tracking and adaptation are still planned features.

## My progress so far

I've built out my player and level foundation with a custom mannequin, Starter Assets third-person movement, and an expanded ProBuilder greybox. My level includes circular platforms, stairs, narrow traversal, an arch/tube obstacle, cones, and merging routes.

My first custom C# script is [MovingObstacle.cs](Assets/Synty/Scripts/MovingObstacle.cs). My saved greybox scene now uses it for vertical arch movement and two horizontally moving cones. These are configured behaviors; I still need to record a completed movement test.

## Lab environment and course layout

I've expanded the greybox presentation with a `LabEnvironment` group containing a floor and four walls: left, right, start, and end. I've added floor and wall textures with separate `MAT_LabFloor` and `MAT_LabWall` materials. This gives the course a lab setting that supports the machine-learning training-environment concept.

I've now added `LabCeiling` to the lab environment with its own `MAT_LabCeiling` material. The wall, floor, and ceiling texture images were generated with AI. I placed them in Unity and adapted them to fit the level myself, including their material settings and tiling. The ceiling material uses tiling of 4.44 by 7.93 and a texture offset to align the image with the surface.

I've also adjusted the obstacle layout, raising three cones and the risk ramp and repositioning the moving arch/tube. The saved scene includes further ProBuilder geometry edits. This update focuses on the environment, materials, and obstacle placement; the C# scripts are unchanged.

I'm working with texture tiling as well as object placement: the floor material uses tiling of 8 by 12. I've reduced the wall material's tiling from 24.22 by 4.4 to 8 by 2, making the texture repeat fewer times across the same surfaces. I've also lowered all four walls and the ceiling to refine the enclosure's placement. My next check is how the surfaces, obstacle spacing, and camera view work together during traversal. I haven't recorded a Play mode result for this environment update yet.

I've started separate material assets for neutral platforms, the harder route, and the safer route: `MAT_PlatformNeutral`, `MAT_RouteHard`, and `MAT_RouteSafe`. Their saved base colors are currently all white, so this is an initial material setup rather than a completed visual distinction between routes.

## My first script: moving obstacles

I'm learning how to move an object relative to its starting position. The script saves that position in `Start()`, then uses `Update()` to apply a changing offset. A sine value makes the motion repeat smoothly in both directions.

I can adjust the direction, distance, and speed through the component's fields. With the default distance of 0.5, the offset reaches 0.5 units on either side of the starting position, giving a total travel range of 1 unit. The speed setting controls how quickly the motion repeats.

One early issue was a mismatch between the field I declared, `moveDirection`, and the name used in the movement calculation, `movementDirection`. I asked Codex to explain the code and help identify errors, then asked it to make that correction. This is a specific instance of direct code assistance.

The saved arch and cone components use a movement distance of 0.75, giving a total travel range of 1.5 units. The arch uses a speed setting of 1, and the cones use 0.5. My next step is to test their motion in Unity, adjust one setting at a time, and record the results.

## Scope decision: defer platform carrying

I explored carrying the player through trigger-based parenting and then a separate rider script that used the obstacle's movement each frame. The parenting attempt did not carry my player during testing, and I have not recorded a successful result for the rider approach. Because of the time constraint, I decided to defer carrying and return to the original sine movement. Both experimental carry scripts have been removed.

I asked Codex to restore the obstacle movement directly. The script retains a compatibility attribute for the temporarily renamed direction field so existing Inspector values can be preserved. This work helped distinguish moving an obstacle from making the player travel with it; carrying needs its own detection and movement logic.

The leftover carry components have now been removed from my saved scene, along with the cones' experimental trigger colliders and Rigidbodies.

## Camera and fall recovery

I've adjusted the course camera's distance, shoulder offset, vertical arm length, field of view, and angle override as part of improving the view of the obstacles. The saved camera distance is 4.5 and the field of view is 55. I still need to record how the revised framing feels during traversal.

I've also added [PlayerRespawn.cs](Assets/Synty/Scripts/PlayerRespawn.cs). It saves the player's starting position and rotation, then restores them if the player falls below Y = -10. It temporarily disables the Character Controller while repositioning the player. This gives the course a basic fall-recovery mechanism without adding checkpoints yet.

I corrected a mistyped `private` keyword and a missing closing brace after asking for help identifying the syntax errors. The respawn script does not reset the movement controller's stored falling velocity; repeat falls and landing behavior still need testing in Unity.

## Calibration counter

I've added [CalibrationManager.cs](Assets/Scripts/CalibrationManager.cs) and set up the counter UI in Unity. The manager starts the collected count at zero, displays it through TextMeshPro, and adds one whenever `CollectData()` is called. The target defaults to three. This gives me a counter for calibration pickups within the training-environment concept; it does not implement behavior tracking or adaptation.

I asked for a code review to double-check the manager. The current script needs an assigned text reference and a single manager in the scene. It does not yet limit the count or trigger completion when the target is reached.

I've added pickup behavior to [CalibrationCollectible.cs](Assets/Scripts/CalibrationCollectible.cs), attached the script in Unity, and tested it successfully. When an object tagged `Player` enters the trigger, the script marks the pickup as collected, calls the manager to update the counter, and destroys the pickup object. The `collected` flag prevents the same pickup from being counted again.

## Data shard animation

I've added [DataShardAnimation.cs](Assets/Scripts/DataShardAnimation.cs) to give the calibration shards a floating, rotating glitch effect that fits the simulated training environment. The shard rotates around the vertical axis and bobs around its starting position. Two child fragments shift in opposite horizontal directions, with one also moving vertically, to create a repeating visual distortion.

This builds on the sine offsets used for my moving obstacles. The shard's bob uses world position, while the fragments use local positions so their offsets follow the rotating shard. My saved scene includes three animation components with a rotation speed of 55 degrees per second, bob height of 0.12, bob speed of 2, glitch distance of 0.06, and glitch speed of 10. The glitch is a repeating movement effect; collection and counting remain in their separate scripts.

The animation is implemented and saved in the scene. I've tested collection in Unity with the glitch animation active and confirmed that it works.

## Planned finish: energy wall

I plan to replace the current finish marker with a glowing cyan, semi-transparent emissive energy wall that the player can walk through. A trigger will detect the player crossing it, end the level, and change the UI to `CALIBRATION COMPLETE`. I'll either stop level movement or disable player input when the run ends; that implementation choice is still open.

This finish behavior is not implemented or tested yet. Showing collected data and completion time is an optional later addition.

## How I'm learning

I write and fix the code myself whenever I can, using AI for explanations, guidance, and a second look when I'm unsure. I work through one concept at a time so I can understand the changes I'm making. When I'm stuck, I ask for a more direct example or help with a specific edit.

I want to be honest about that process. I distinguish between work I do myself, work I do with guidance, and code changes made with direct AI assistance. My goal is to build my understanding alongside the game.

## What comes next

- I'll test traversal and camera visibility in the new lab enclosure, including the revised obstacle positions and texture scale.
- I'll implement and test the planned energy-wall finish. I'll also decide whether reaching the calibration pickup target is required to finish.
- I'll test and tune the vertical arch movement.
- I'll test and tune the configured horizontal cone movement.
- I'll test the revised camera framing and fall recovery, including repeated falls.
- I'll continue developing the choice between easier and harder routes.
- Later, I'll decide what player behavior to record and how it should affect a subsequent run.

I'll keep this page and my commit history focused on what changes, why I make those decisions, and what I learn along the way.
