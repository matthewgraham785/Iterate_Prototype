# ITERATE

ITERATE is a Unity prototype built around a laboratory training course: the player moves through a hazard-filled environment, gathers calibration data, chooses between safer and riskier routes, and finishes the run by reaching a gate that evaluates the collected evidence.

The repository documents the completed prototype as a design and development project rather than a polished commercial game. I made the creative decisions, designed the levels, implemented the systems, and made the final calls on what belonged in the project. I used AI as a tutor and development assistant to explain Unity and C# concepts, troubleshoot specific problems, review code and documentation, and occasionally provide targeted help when I became stuck. The project is not presented as independently created by AI; it reflects my decisions, design work, and execution.

## Prototype status

This repository now contains a complete beginning-to-end playable prototype with the following scenes and flow:

- `Assets/Scenes/MainMenu.unity`
- `Assets/Scenes/IterateLevel.unity`
- `Assets/Scenes/EasyResultRoom.unity`
- `Assets/Scenes/HardResultRoom.unity`

The full run is:

Main Menu -> Begin Calibration -> tutorial pedestal briefing -> lab course -> shard collection -> finish gate -> result room -> Restart Room / Main Menu

## Main menu and scene navigation

The project begins in `MainMenu`, which presents the ITERATE title and the option to begin the calibration run. The menu is driven by `Assets/Scripts/MainMenuController.cs`, which loads the gameplay scene named `IterateLevel` when the player starts. The project build order is structured so the main menu loads first, then the training scene, and then the easy or hard outcome scenes depending on the player’s collected data.

The gameplay loop continues into the result rooms, where the player can restart the active scene or return to the menu. The result rooms are designed as short completion states rather than final game environments, and each one includes a working completion panel with action buttons.

## Controls and player movement

The player uses the Starter Assets third-person controller found in `Assets/StarterAssets/ThirdPersonController/Scripts/ThirdPersonController.cs`.

Controls:

- Move: `WASD` or arrow keys
- Look: mouse movement
- Jump: `Space`
- Sprint: `Left Shift`
- Interact: `E` near the tutorial terminal
- Pause: `Esc`

The character controller supports standard third-person movement with a sprint modifier, jumping, gravity, and camera-follow rotation. The camera is anchored to the player through the third-person camera rig and uses mouse input for looking around the environment.

## Tutorial pedestal and controls UI

The game opens with a tutorial pedestal and briefing prompt placed near the starting area. The pedestal is paired with `Assets/Scripts/TutorialTerminal.cs`, which shows a movement prompt when the player is nearby and opens a briefing panel when the player presses `E`.

The briefing explains the primary movement controls, camera handling, jump and sprint behavior, and the objective of the calibration run. The tutorial panel also introduces the two data categories and the minimum shard requirement before the finish gate is accepted.

## Laboratory environment and route design

The course is built as a laboratory training environment with a clear sense of route choice and hazard timing. The level uses ProBuilder-created platforms and modular geometry to support a structured but varied platformer layout. The obstacle shapes and platform spacing intentionally force the player to read the route rather than simply moving forward without thinking.

The environment includes:

- platforming routes with different levels of risk
- a safe or more stable path and a more hazardous path
- varied obstacle placements and ProBuilder geometry
- moving obstacles and hazard props placed to create readable timing windows

## Moving obstacles and hazard timing

Moving obstacles are driven by `Assets/Synty/Scripts/MovingObstacle.cs`, which stores an initial position and applies a sine-wave offset along a configured direction vector. This creates the repeating motion used by the arch and cone-style objects in the level.

The project uses a combination of passive and active hazards to reinforce the training-environment concept:

- moving obstacle shapes with repeated motion timing
- red rotating laser hazards built around `Assets/Scripts/RotatingHazard.cs`
- trigger-based laser danger logic in `Assets/Scripts/LaserHazard.cs`
- fall detection and player respawn in `Assets/Synty/Scripts/PlayerRespawn.cs`

## Fall detection and respawn

The player respawn system is simple and deliberate: when the player falls below a configured threshold, the character is restored to its starting transform. This keeps the prototype testable and prevents a single slip from ending the run in a confusing way.

The laser hazards immediately reset the player when they are triggered, and the player is also restored if they fall out of the course. The goal is to keep the player in a consistent flow while testing obstacle timing and route decisions.

## Calibration data system

The project tracks two categories of calibration data:

- cyan Stability shards
- orange Risk shards

The system is managed by `Assets/Scripts/CalibrationManager.cs` and `Assets/Scripts/CalibrationCollectible.cs`.

There are exactly three Stability shards and three Risk shards in the level, for a total of six collectible data points. The HUD displays the totals in separate counters so the player can see the route breakdown while they play.

The separate counters supported by the manager are essential to the route-analysis concept of the project. Stability and Risk are tracked independently, and the final gate uses that information to decide where the player should continue.

## Finish gate and branching logic

The finish gate is handled by `Assets/Scripts/FinishGate.cs` and uses the total collected shards as the branching factor.

The logic in the current prototype is:

- 0–2 shards: display an insufficient-data warning and do not complete the run
- 3–5 shards: load `EasyResultRoom`
- 6 shards: load `HardResultRoom`

This means the player must collect at least three shards before the gate accepts the run, and a full set of six shards triggers the harder result room.

## Easy and hard result rooms

The result rooms are separate completion scenes intended to reflect different outcome states:

- `EasyResultRoom`: a more forgiving route outcome with a mildly challenging obstacle course and a clear successful completion panel
- `HardResultRoom`: a more difficult outcome with smaller platforms, altered spacing, and a harder layout

Both rooms include working completion screens and the same basic result-room flow. The completion scripts in `Assets/Scripts/ResultRoomFinish.cs` show a panel with a completion message, then allow the player to restart the room or return to the Main Menu.

## Audio and feedback

The prototype includes the following feedback systems:

- shard collection sound effects
- laser hazard audio feedback
- looping background music
- UI and gameplay emphasis through color-coded data categories

The sound layer supports the game’s lab-and-training theme and makes the hazard and collection states easier to read while the player is focused on movement and route timing.

## Pause menu and completion actions

The pause system is handled by `Assets/Scripts/PauseMenu.cs`, and it is now functional in all three playable scenes: the original calibration level, `EasyResultRoom`, and `HardResultRoom`. The menu allows the player to:

- resume the run
- restart the current trial
- return to the main menu
- quit the game

The pause menu uses the standard Escape input pattern and temporarily unlocks the cursor so the player can interact with the menu. The same pause flow remains consistent across the main gameplay loop and the two result rooms.

The Easy and Hard result-room completion panels are also working. Each result room includes a completion screen with navigation buttons for restarting the room and returning to the main menu, and those buttons are functional in the current prototype.

## Project structure and key scripts

Core scripts in the project include:

- `Assets/Scripts/CalibrationManager.cs` — tracks Stability and Risk totals and updates the HUD
- `Assets/Scripts/CalibrationCollectible.cs` — handles shard pickup and sound feedback
- `Assets/Scripts/FinishGate.cs` — blocks early completion and routes to the correct result room
- `Assets/Scripts/ResultRoomFinish.cs` — displays the end-of-run result panel and navigation buttons
- `Assets/Scripts/LaserHazard.cs` — triggers player respawn when a laser is touched
- `Assets/Scripts/RotatingHazard.cs` — rotates hazard objects in place
- `Assets/Scripts/TutorialTerminal.cs` — opens and closes the onboarding briefing
- `Assets/Scripts/MainMenuController.cs` — handles the menu flow
- `Assets/Scripts/PauseMenu.cs` — handles in-game pause state and scene navigation
- `Assets/Synty/Scripts/MovingObstacle.cs` — drives sine-based obstacle motion
- `Assets/Synty/Scripts/PlayerRespawn.cs` — returns the player to the start transform when they fall

## Current project summary

The current iteration of ITERATE is a complete prototype rather than a placeholder build. It contains a full starting menu, a tutorial briefing, collectible route data, a branching finish gate, separate easy and hard result scenes, hazard and respawn systems, audio feedback, pause-menu support across all playable scenes, and working result-room completion navigation. The prototype is intentionally focused on readability, route evaluation, and learning rather than on a broad feature set beyond the current training-environment loop.

## Development note

I am keeping this repository honest about what is complete and what remains conceptual. The project is not presented as a finished production game, and the machine-learning adaptation layer remains a future direction rather than a current feature. The prototype successfully captures the core loop of route-based decision-making, hazard timing, and calibration evaluation in a compact Unity project.
