# ITERATE

I'm building ITERATE as an eight-week solo Unity 3D platformer. My goal is to create a level that feels like a machine-learning training environment, with choices that eventually influence a later run.

## My concept

I give the player a choice between an easier route and a more difficult route. Those routes eventually merge. I plan to track player behavior and use that information to adapt a subsequent run. That system is still planned; I have not established a working trained machine-learning model in this project.

## My current progress

My current foundation includes a working custom mannequin, Starter Assets third-person movement, and an expanded ProBuilder greybox. I have circular platforms, stairs, narrow traversal, an arch/tube obstacle, cones, and routes that merge. This is the progress I've described during development; Codex has not independently verified it in Play mode.

My first custom C# task is to move the arch vertically. Once that works, I want to apply the same concept to two cones moving horizontally. My script is at `Assets/Synty/Scripts/MovingObstacle.cs`. I originally referred to `Assets/Scripts/MovingObstacle.cs`, but that isn't its actual location.

## How I open and check the project

1. I add the project root folder to Unity Hub.
2. I use the editor version recorded in `ProjectSettings/ProjectVersion.txt`: `6000.4.0f1` at the time of inspection.
3. I allow Unity to import assets and resolve the dependencies in `Packages/manifest.json` and the package lock file.
4. I select my working scene before testing. My saved scenes include `Assets/ITERATE_Prototype.unity`, `Assets/ITERATE_Greybox_01.unity`, and `Assets/ITERATE_Greybox_03.unity`. I still need to confirm the active scene in this review.
5. I check the Console and use Play mode to test the specific behavior I'm working on.

My project includes Input System, Cinemachine, ProBuilder, and Universal Render Pipeline dependencies. My saved build scene list currently enables `Assets/Scenes/SampleScene.unity`, so I still need to select and verify the intended scene before preparing a release build.

## What I'm learning from the moving obstacle

I'm using this script to learn how a saved position and a changing offset work together. The script records its starting world position, then adds a sine-based offset every frame. With the default settings, it moves vertically up to 0.5 units on either side of that position. The speed field controls how quickly the motion repeats.

I asked Codex to review and explain the script before making changes. Codex found that I declared `moveDirection` but used `movementDirection` in the position calculation. I approved the correction, and Codex made that edit.

I still need to verify compilation and motion in Unity. Codex found no references to the script's GUID in saved scenes or prefabs, so I also need to confirm that the component is attached to the intended obstacle. That inspection doesn't tell me whether I have unsaved changes in the Editor.

## How I use Codex

I use Codex as a tutor and reviewer. I want to understand the purpose of a change before it is made, work through one concept at a time, and test meaningful changes before moving on. I use small Git commits as checkpoints so I can review progress and return to an earlier state when needed.

I keep my collaboration instructions in `AGENTS.md`. My personal planning and development notes stay local and are excluded from Git. I share the project through my public repository: [Iterate_Prototype](https://github.com/matthewgraham785/Iterate_Prototype).
