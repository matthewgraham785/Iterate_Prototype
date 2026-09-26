# ITERATE

I'm building ITERATE as an eight-week solo Unity 3D platformer. I use this repository to show my progress, share my code, and explain how the project develops as I learn.

## What I'm building

I'm presenting the level as a machine-learning training environment. The player chooses between safer and riskier routes that eventually merge, and the broader idea is to track behavior and adapt a later run based on that data. The current prototype is not yet fully adaptive, but it is now structured to support decision tracking and route comparison in a way that feels closer to an RL-style training loop.

## Current progress

I have a working greybox course with a lab-inspired enclosure, route colors, a calibration loop, hazard behavior, respawn logic, and a finish gate. The level now reads like a test environment rather than a placeholder room, and the scripts are built around the motion and danger patterns I need for the prototype.

## The current course

The level includes a lab environment, route separation, a moving arch, two moving cones, six collectible data shards total, rotating and laser hazards, a respawn system, and a finish gate. There are three orange-coded shards on the safe route and three orange-coded shards on the risk route, so each path leaves a visible route identity in the collected data. This makes the prototype feel more like a true training environment for machine-learning or reinforcement-learning decision analysis.

The course uses a `LabEnvironment` with floor, walls, and ceiling, plus separate materials for the neutral route, hard route, and safe route. The saved course also includes a cyan energy gate and associated completion panel. The obstacle layout is now part of the level rather than isolated experiments.

## Script overview

### Movement and obstacle logic

- [Assets/Synty/Scripts/MovingObstacle.cs](Assets/Synty/Scripts/MovingObstacle.cs): copies a saved start position, then applies a sine-wave offset to move along a direction vector. This drives the vertical arch and horizontal cone movement.
- [Assets/Scripts/RotatingHazard.cs](Assets/Scripts/RotatingHazard.cs): rotates an object around its own local axis at a configured speed. This is useful for spinning obstacles and hazard geometry.
- [Assets/Scripts/LaserHazard.cs](Assets/Scripts/LaserHazard.cs): detects a player collider and calls the respawn flow when tagged appropriately.

### Player flow and systems

- [Assets/Synty/Scripts/PlayerRespawn.cs](Assets/Synty/Scripts/PlayerRespawn.cs): saves the start position and rotation, then restores the player if they fall below the set threshold.
- [Assets/Scripts/CalibrationManager.cs](Assets/Scripts/CalibrationManager.cs): keeps a collected-data counter and updates the UI text.
- [Assets/Scripts/CalibrationCollectible.cs](Assets/Scripts/CalibrationCollectible.cs): marks a pickup as collected, informs the manager, and destroys the collectible when the player touches it.
- [Assets/Scripts/DataShardAnimation.cs](Assets/Scripts/DataShardAnimation.cs): adds the floating and glitch-style motion to the calibration units.
- [Assets/Scripts/FinishGate.cs](Assets/Scripts/FinishGate.cs): triggers level completion, shows the completion panel, pauses time, and unlocks the cursor.

## Complete systems in the prototype

### Calibration loop

The calibration system is now working as a route-aware loop: the player collects orange data shards, the manager updates the count, and the route-specific collection adds context for future decision analysis. The safe and risk sides each contain three shards, so the prototype can distinguish which path the player took while still keeping the loop simple and readable. The collectibles remain separate from the animation, which keeps the visual effect distinct from the gameplay logic.

### Hazard loop

The rotating hazard and laser hazard are built as simple danger components with clear behavior. The spinning object rotates continuously in local space, and the contact-based laser triggers the player respawn. This keeps the hazard logic readable and easy to tune in the Inspector.

### Recovery and progression

The player respawn system handles falling out of the course, and the finish gate pauses the game when the player reaches the end. That gives the prototype a clear flow: traverse, collect route-specific data, survive hazards, reach the end, and complete the run.

## What I learned

I improved my understanding of several Unity patterns in this build:

- A sine-wave offset is a clean way to make an obstacle move back and forth without a rigidbody.
- Rotation and motion should be separated when I want the object to spin while keeping its path independent.
- Script logic should stay readable: hazard behavior, collection behavior, and UI/counter behavior each have a distinct responsibility.
- A respawn system is much more useful when it is simple and consistent, even before I add checkpoints or deeper tracking.

## Current status

The current version of the project is in a testable state. I have updated the obstacle layouts, materials, hazard scripts, route-specific collectible loop, respawn logic, and finish gate, and I have confirmed the behavior in Unity while working through the prototype. The orange-shard setup now supports the prototype's ML/RL direction by making route decisions more legible and more useful for later analysis. I am now at the point where the code, scene, and documentation are aligned enough to commit the project state.

## Next steps

The next improvements are not a rebuild from scratch; they are refinements to the current prototype:

- test traversal timing against the hazard placement
- tune obstacle speed and spacing for readability and difficulty
- decide whether the finish gate should require all collected route shards before completion
- expand the behavioral tracking logic so route choice and run outcome are recorded more explicitly
- use the next run to evaluate whether the route choice, hazard pacing, and collected data feel intentional for the training-environment concept

This page reflects my current design and progress. I keep the documentation tied to what is actually in the scene and in the code so the repository stays honest as the project grows.
