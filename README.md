# ITERATE

I'm building ITERATE as an eight-week solo Unity 3D platformer. I use this repository to show my progress, share my code, and explain how the project develops as I learn.

## What I'm building

I'm presenting the level as a machine-learning training environment. The player chooses between an easier route and a more difficult route, and those routes eventually merge. My longer-term goal is to track player behavior and use it to adapt a later run. Behavior tracking and adaptation are still planned features.

## My progress so far

I've built out my player and level foundation with a custom mannequin, Starter Assets third-person movement, and an expanded ProBuilder greybox. My level includes circular platforms, stairs, narrow traversal, an arch/tube obstacle, cones, and merging routes.

My first custom C# script is [MovingObstacle.cs](Assets/Synty/Scripts/MovingObstacle.cs). My saved greybox scene now uses it for vertical arch movement and two horizontally moving cones. These are configured behaviors; I still need to record a completed movement test.

## My first script: moving obstacles

I'm learning how to move an object relative to its starting position. The script saves that position in `Start()`, then uses `Update()` to apply a changing offset. A sine value makes the motion repeat smoothly in both directions.

I can adjust the direction, distance, and speed through the component's fields. With the default distance of 0.5, the offset reaches 0.5 units on either side of the starting position, giving a total travel range of 1 unit. The speed setting controls how quickly the motion repeats.

One early issue was a mismatch between the field I declared, `moveDirection`, and the name used in the movement calculation, `movementDirection`. I asked Codex to explain the code and help identify errors, then asked it to make that correction. This is a specific instance of direct code assistance.

The saved arch and cone components use a movement distance of 0.75, giving a total travel range of 1.5 units. The arch uses a speed setting of 1, and the cones use 0.5. My next step is to test their motion in Unity, adjust one setting at a time, and record the results.

## Scope decision: defer platform carrying

I explored carrying the player through trigger-based parenting and then a separate rider script that used the obstacle's movement each frame. The parenting attempt did not carry my player during testing, and I have not recorded a successful result for the rider approach. Because of the time constraint, I decided to defer carrying and return to the original sine movement. Both experimental carry scripts have been removed.

I asked Codex to restore the obstacle movement directly. The script retains a compatibility attribute for the temporarily renamed direction field so existing Inspector values can be preserved. This work helped distinguish moving an obstacle from making the player travel with it; carrying needs its own detection and movement logic.

My saved scene still has two disabled component references to the deleted carry script. Removing those missing components in Unity remains a cleanup task.

## How I'm learning

I write and fix the code myself whenever I can, using AI for explanations, guidance, and a second look when I'm unsure. I work through one concept at a time so I can understand the changes I'm making. When I'm stuck, I ask for a more direct example or help with a specific edit.

I want to be honest about that process. I distinguish between work I do myself, work I do with guidance, and code changes made with direct AI assistance. My goal is to build my understanding alongside the game.

## What comes next

- I'll test and tune the vertical arch movement.
- I'll test and tune the configured horizontal cone movement.
- I'll remove the leftover missing carry components from the scene.
- I'll continue developing the choice between easier and harder routes.
- Later, I'll decide what player behavior to record and how it should affect a subsequent run.

I'll keep this page and my commit history focused on what changes, why I make those decisions, and what I learn along the way.
