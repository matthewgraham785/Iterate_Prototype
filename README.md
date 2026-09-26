# ITERATE

This project is my Unity prototype for a small platformer built around a simple idea: I want a course that feels like a training environment, where a player makes route decisions, learns the hazard patterns, and eventually reaches a clear end state. I’m not building a polished game yet. I’m building a testable prototype and learning from it as I move.

I’m using this repository to keep a record of what I’m trying, what I change, and what I learn along the way. The goal is not to hide the rough edges. It’s to make the project readable and honest, especially as I work through Unity and C# on my own.

## How I work on this project

I write the code I can myself and I try to understand the problem before I ask for help. I use Codex primarily as a tutor while I learn Unity and C#. I’ll ask it to explain a concept, check my logic, or help me understand why something is behaving differently than I expected.

When I get stuck, I want Codex to guide me through the issue so I can understand it and fix it myself. That is the pattern I’m trying to keep: me doing the work, then asking for feedback and explanation, then returning to the code and making the next pass. Sometimes I ask for more direct help on a specific problem, but even then the goal is still learning and understanding, not handing over the design.

I also use Codex to help keep documentation current, including this README. That means I am being explicit about where the help is useful and where I still need to own the decisions. I’m not claiming I built everything on my own without assistance, and I’m not pretending Codex built the game for me. I’m trying to be accurate about what I wrote, what I changed, and what I asked for help with.

## What I’m building

The basic idea is a lab-style obstacle course with route separation. The player has a safe route and a risk route, and those routes eventually point toward the same objective. I want the level to feel like a training loop where I can compare decision-making, timing, and hazard recognition later.

Right now the prototype is not fully adaptive. It is more of a structured environment for route choice and obstacle timing than a complete ML pipeline. But the project is already pointing in that direction. I want the course to be readable as a training space, not just a maze with a few hazards in it.

## What is in the repo right now

The current layout includes a lab-inspired room, route separation, a moving tube object, two moving cone obstacles, six collectible data shards, two laser hazards, a respawn system, and a finish gate. The safe route and risk route each have three orange shard pickups, so there is a visible distinction between the two paths.

The scene also includes a cyan energy gate and a completion panel, and the obstacle layout is part of the level instead of being a disconnected test setup. The scripts in the project are clearly organized around movement, hazard behavior, collection, respawn, and progression.

### Relevant scripts

- [Assets/Synty/Scripts/MovingObstacle.cs](Assets/Synty/Scripts/MovingObstacle.cs): this script stores a start position and applies a sine-wave offset to move an object along a direction vector. In the current course, that is driving the moving tube and the cone motion.
- [Assets/Scripts/LaserHazard.cs](Assets/Scripts/LaserHazard.cs): this is a trigger-based danger script that checks for the player and calls the respawn flow.
- [Assets/Synty/Scripts/PlayerRespawn.cs](Assets/Synty/Scripts/PlayerRespawn.cs): this stores the player’s start transform and restores it when the player falls below a threshold.
- [Assets/Scripts/CalibrationManager.cs](Assets/Scripts/CalibrationManager.cs): this tracks collected route data and updates the UI text.
- [Assets/Scripts/CalibrationCollectible.cs](Assets/Scripts/CalibrationCollectible.cs): this marks a collectible as collected and removes it when the player touches it.
- [Assets/Scripts/DataShardAnimation.cs](Assets/Scripts/DataShardAnimation.cs): this adds the motion and visual effect for the data shard pickups.
- [Assets/Scripts/FinishGate.cs](Assets/Scripts/FinishGate.cs): this triggers level completion and pauses the game when the player reaches the end.

There is also a [Assets/Scripts/RotatingHazard.cs](Assets/Scripts/RotatingHazard.cs) script in the project. I still have that as a hazard concept, but the current active obstacle layout is not built around a spinning hazard. The moving tube is the obstacle I am currently treating as the main movement-based danger, and the two laser hazards are the hazard objects I am currently using as contact triggers.

## What is working in the current build

The project currently includes the pieces I need for the loop I want to test:

- a route-based level layout
- collectible data shards on both paths
- a respawn system for falls and repeated trial runs
- movement-based obstacles that shift the player’s timing
- laser triggers that punish contact
- a finish gate that signals completion

I would still describe this as a prototype rather than a fully tuned level. The logic is simple and readable, which is useful to me right now, and the structure is clear enough that I can iterate on it without reworking unnecessary systems.

## What I am still figuring out

I’m still learning how to tune obstacle spacing, movement speed, and hazard placement so the route reads clearly. I want the player to understand the risk and safe options without the course feeling arbitrary or unfair.

I’m also still deciding how much route data I actually need to record and how explicit I want the training-environment structure to become. The current prototype is enough to support the idea, but I’m not pretending the entire machine-learning layer is already built out.

The next pass is mostly about refining the prototype instead of rewriting it. I want to test lane timing against the obstacle placement, adjust the motion curves so they feel intentional, and decide whether the finish gate should require all route data before completion. Those are the next design decisions I need to make, not just the next technical tasks.

## My learning goals

This is a learning project as much as a game project. I’m trying to get better at Unity level structure, C# scripting, movement patterns, and hazard readability. I want to keep the project honest and explainable, which is one reason I’m writing the README like this instead of pretending it is a perfectly polished progression.

I’m building the course one concept at a time, and I’m keeping the process visible because that is part of what I want this repository to show: not just the final object, but the decisions behind it, the learning that comes with it, and the honest state of the project as it changes.

This is not a claim that I have everything solved. It is just where the project stands right now, and I’m continuing from there.
