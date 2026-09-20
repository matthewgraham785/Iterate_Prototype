# ITERATE

An eight-week solo Unity 3D platformer by Matthew Graham.

## Concept

The level is presented as a machine-learning training environment. Players choose between an easier route and a difficult route, which eventually merge. The intended later system will track player behavior and adapt a subsequent run. This framing does not establish that a trained machine-learning model has been implemented.

## Current progress

Matthew reports a working custom mannequin, Starter Assets third-person movement, an expanded ProBuilder greybox, circular platforms, stairs, narrow traversal, an arch/tube obstacle, cones, and merging routes. These gameplay elements have not been independently verified in Play mode during this review.

The first custom C# task is a moving obstacle: vertical motion for the arch, followed by horizontal motion for two cones. The script exists at `Assets/Synty/Scripts/MovingObstacle.cs`, not the initially requested `Assets/Scripts/MovingObstacle.cs` path.

## Opening the project

1. Add this root folder to Unity Hub.
2. Open with the editor version recorded in `ProjectSettings/ProjectVersion.txt`: `6000.4.0f1` at the time of inspection.
3. Allow Unity to import assets and resolve the packages in `Packages/manifest.json` and the existing package lock file.
4. Select the intended working scene before testing. Saved scenes include `Assets/ITERATE_Prototype.unity`, `Assets/ITERATE_Greybox_01.unity`, and `Assets/ITERATE_Greybox_03.unity`; the active working scene is not yet confirmed.
5. Check the Console and enter Play mode for the behavior under review.

The inspected manifest includes Starter Assets-related input support through Input System, Cinemachine, ProBuilder, and Universal Render Pipeline dependencies. The saved build scene list currently enables `Assets/Scenes/SampleScene.unity`; choosing the release scene remains a later task.

## Moving obstacle status

The script saves its starting world position, then applies a sine-based offset every frame. Its default direction is up, its offset reaches 0.5 units on each side, and its speed field controls the rate of oscillation. An earlier variable-name mismatch was corrected with Codex assistance.

Source review found no remaining instance of that mismatch. Compilation and gameplay have not yet been tested by Codex. No references to the script's GUID were found in saved `.unity` or `.prefab` files during inspection; attachment to the intended obstacle is unverified, including any unsaved Editor changes.

## Development approach

Matthew develops the project with Codex as a tutor and reviewer. Work proceeds one concept at a time: explain, make a small change, test, reflect, and create a focused Git checkpoint once repository initialization is approved.

See `AGENTS.md` for collaboration rules. Personal planning, learning, and development notes remain local and excluded from version control. The project uses local Git checkpoints and the public GitHub repository [Iterate_Prototype](https://github.com/matthewgraham785/Iterate_Prototype).
