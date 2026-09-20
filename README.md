# ITERATE

I'm building ITERATE as an eight-week solo Unity 3D platformer. I use this repository to show my progress, share my code, and explain how the project develops as I learn.

## What I'm building

I'm presenting the level as a machine-learning training environment. The player chooses between an easier route and a more difficult route, and those routes eventually merge. My longer-term goal is to track player behavior and use it to adapt a later run. Behavior tracking and adaptation are still planned features.

## My progress so far

I've built out my player and level foundation with a custom mannequin, Starter Assets third-person movement, and an expanded ProBuilder greybox. My level includes circular platforms, stairs, narrow traversal, an arch/tube obstacle, cones, and merging routes.

I'm now working on my first custom C# script: [MovingObstacle.cs](Assets/Synty/Scripts/MovingObstacle.cs). My immediate goal is to move the arch vertically. After that, I want to apply the same movement concept to two cones moving horizontally.

## My first script: moving obstacles

I'm learning how to move an object relative to its starting position. The script saves that position in `Start()`, then uses `Update()` to apply a changing offset. A sine value makes the motion repeat smoothly in both directions.

I can adjust the direction, distance, and speed through the component's fields. With the default distance of 0.5, the offset reaches 0.5 units on either side of the starting position, giving a total travel range of 1 unit. The speed setting controls how quickly the motion repeats.

One early issue was a mismatch between the field I declared, `moveDirection`, and the name used in the movement calculation, `movementDirection`. I asked Codex to explain the code and help identify errors, then asked it to make that correction. This is a specific instance of direct code assistance.

My next step is to test the arch's motion in Unity, adjust one setting at a time, and record what works before moving on to the cones.

## How I'm learning

I write and fix the code myself whenever I can, using AI for explanations, guidance, and a second look when I'm unsure. I work through one concept at a time so I can understand the changes I'm making. When I'm stuck, I ask for a more direct example or help with a specific edit.

I want to be honest about that process. I distinguish between work I do myself, work I do with guidance, and code changes made with direct AI assistance. My goal is to build my understanding alongside the game.

## What comes next

- I'll test and tune the vertical arch movement.
- I'll apply the same concept to horizontal cone movement.
- I'll continue developing the choice between easier and harder routes.
- Later, I'll decide what player behavior to record and how it should affect a subsequent run.

I'll keep this page and my commit history focused on what changes, why I make those decisions, and what I learn along the way.
