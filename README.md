# ITERATE

This project is my Unity prototype for a small platformer built around a simple idea: I want a course that feels like a training environment, where a player makes route decisions, learns the hazard patterns, and eventually reaches a clear end state. I’m not building a polished game yet. I’m building a testable prototype and learning from it as I move.

I’m using this repository to keep a record of what I’m trying, what I change, and what I learn along the way. The goal is not to hide the rough edges. It’s to make the project readable and honest, especially as I work through Unity and C# on my own.

## How I work on this project

I write the code I can myself and I try to understand the problem before I ask for help. I use Codex primarily as a tutor while I learn Unity and C#. I’ll ask it to explain a concept, check my logic, or help me understand why something is behaving differently than I expected.

When I get stuck, I want Codex to guide me through the issue so I can understand it and fix it myself. That is the pattern I’m trying to keep: me doing the work, then asking for feedback and explanation, then returning to the code and making the next pass. Sometimes I ask for more direct help on a specific problem, but even then the goal is still learning and understanding, not handing over the design.

I also use Codex to help keep documentation current, including this README. That means I am being explicit about where the help is useful and where I still need to own the decisions. I’m not claiming I built everything on my own without assistance, and I’m not pretending Codex built the game for me. I’m trying to be accurate about what I wrote, what I changed, and what I asked for help with.

The transparent cyan-and-amber ITERATE calibration emblem in the menu background was created with OpenAI image generation. This attribution applies to that visual asset, not to the project’s gameplay code or design.

## What I’m building

The basic idea is a lab-style obstacle course with route separation. The player has a safe route and a risk route, and those routes eventually point toward the same objective. I want the level to feel like a training loop where I can compare decision-making, timing, and hazard recognition later.

Right now the prototype is not fully adaptive. It is more of a structured environment for route choice and obstacle timing than a complete ML pipeline. But the project is already pointing in that direction. I want the course to be readable as a training space, not just a maze with a few hazards in it.

## What is in the repo right now

The current build uses a separate `MainMenu` scene and the `IterateLevel` gameplay scene. The lab-inspired gameplay course includes a Stability route and a Risk route, moving platforms and animated obstacles, separate Stability and Risk data shards, two rotating laser hazards, player respawning, a tutorial terminal, and a finish gate.

The gameplay scene includes the completion panel and route-analysis logic. Diegetic and non-diegetic audio, laser feedback, and shard pickup cues support the training-environment feel. The build scene list in `ProjectSettings/EditorBuildSettings.asset` has `Assets/Scenes/MainMenu.unity` first, followed by `Assets/Scenes/IterateLevel.unity`.

### Relevant scripts

- [Assets/Synty/Scripts/MovingObstacle.cs](Assets/Synty/Scripts/MovingObstacle.cs): this script stores a start position and applies a sine-wave offset to move an object along a direction vector. In the current course, that is driving the moving tube and the cone motion.
- [Assets/Scripts/LaserHazard.cs](Assets/Scripts/LaserHazard.cs): this is a trigger-based danger script that checks for the player and calls the respawn flow.
- [Assets/Synty/Scripts/PlayerRespawn.cs](Assets/Synty/Scripts/PlayerRespawn.cs): this stores the player’s start transform and restores it when the player falls below a threshold.
- [Assets/Scripts/CalibrationManager.cs](Assets/Scripts/CalibrationManager.cs): this tracks collected route data and updates the UI text.
- [Assets/Scripts/CalibrationCollectible.cs](Assets/Scripts/CalibrationCollectible.cs): this marks a collectible as collected and removes it when the player touches it.
- [Assets/Scripts/DataShardAnimation.cs](Assets/Scripts/DataShardAnimation.cs): this adds the motion and visual effect for the data shard pickups.
- [Assets/Scripts/FinishGate.cs](Assets/Scripts/FinishGate.cs): this distinguishes an insufficient-data warning from successful completion, reports the Stability and Risk totals, evaluates route preference, and shows completion actions only after a successful run.
- [Assets/Scripts/TutorialBeaconSpin.cs](Assets/Scripts/TutorialBeaconSpin.cs): this spins the tutorial beacon on multiple axes to visually identify the terminal as interactive.
- [Assets/Scripts/TutorialTerminal.cs](Assets/Scripts/TutorialTerminal.cs): this script handles the tutorial panel, prompt state changes, and keyboard interaction for the onboarding briefing.
- [Assets/Scripts/PauseMenu.cs](Assets/Scripts/PauseMenu.cs): this handles Escape, pausing and resuming, restarting the active trial, returning to the MainMenu scene, and quitting.
- [Assets/Scripts/MainMenuController.cs](Assets/Scripts/MainMenuController.cs): this handles the Begin Calibration and Quit buttons on the main menu.

There is also an [Assets/Scripts/RotatingHazard.cs](Assets/Scripts/RotatingHazard.cs) script for rotating hazards. The current build includes two rotating laser hazards as well as moving obstacles.

## What is working in the current build

ITERATE now has a functional MVP gameplay loop from launch through completion. The current build includes:

- a main menu and a separate onboarding tutorial
- player movement and camera controls
- Easy/Stability and hard/Risk routes
- separate Stability and Risk collectibles with route-specific HUD tracking
- moving platforms and animated obstacles
- two rotating laser hazards and player respawning
- diegetic and non-diegetic audio
- pause, restart, quit, and Main Menu navigation
- a minimum calibration-data requirement and end-of-level behavior analysis
- complete scene navigation from beginning to end

The course is now connected to its start menu, tutorial, calibration, and completion flow rather than being only a collection of individual systems. The MVP loop is functional; its presentation and difficulty still need selective polish.

## Main menu, pause, and completion flow

The saved menu scene is `Assets/Scenes/MainMenu.unity`, and the gameplay scene is `Assets/Scenes/IterateLevel.unity`. Both are enabled in the Unity build scene list, with `MainMenu` loading first. The menu presents “ITERATE” and “ADAPTATION THROUGH ITERATION,” with Begin Calibration loading the gameplay scene and Quit exiting the game or stopping Play mode in the Editor. A separate looping 2D Audio Source plays the menu music, and the background uses the transparent cyan-and-amber calibration emblem. Its dark laboratory interface keeps the established cyan Stability and amber Risk colors.

In gameplay, Escape opens the pause menu, which stops time with `Time.timeScale` and makes the cursor visible and unlocked. Escape or Resume returns to play. Restart Trial reloads the active gameplay scene, Main Menu loads `MainMenu`, and Quit exits a standalone build or stops Editor Play mode. The pause menu does not open when another system has already paused gameplay, so it does not overlap the tutorial or successful completion screen.

At the finish, fewer than three collected shards produce a temporary insufficient-data warning that disappears without pausing the run. With enough data, the completion screen shows the Stability and Risk totals and evaluates the route preference. Restart Trial and Main Menu actions are shown only for successful completion. Returning to the menu restores normal time scale, and menu music transitions to gameplay audio when the gameplay scene loads.

The confirmed route is Main Menu → Begin Calibration → tutorial → gameplay → finish analysis → restart or return to Main Menu. Restarting resets the collected shard data. The tutorial beacon continues to rotate, and cursor behavior works across the menu, gameplay, pause, tutorial, and completion states. The final end-to-end Unity test completed without red Console errors.

## Current onboarding and tutorial pass

I added a small onboarding system at the start of the course so the player can understand the basic controls before moving into the route. A waist-height tutorial pedestal sits near the start area, built from simple geometric shapes to match the laboratory environment. It includes a glowing dark-amber beacon with a custom emissive material, and the beacon rotates continuously to make the terminal clearly readable as interactive.

The tutorial system is built around a separate invisible trigger object with a Box Collider set as a trigger. When the player approaches the pedestal, the initial HUD prompt teaches the basics of movement and points the player toward the amber terminal. Once inside the trigger, the prompt changes to “PRESS E TO ACCESS TRIAL BRIEFING.” Pressing E opens a briefing panel that pauses gameplay and explains movement, camera control, jumping, sprinting, Stability Data, Risk Data, the three-shard requirement, and the objective of reaching the exit for analysis. Pressing E again closes the panel and resumes gameplay.

The tutorial UI keeps amber accents to match the terminal, uses cyan for Stability Data, and uses orange for Risk Data. The panel is functional and readable, even if I expect to do additional visual polish later. The purpose of this pass is to make the prototype easier to understand without turning the tutorial into a full polished onboarding sequence.

## Current audio and feedback pass

The most recent pass was not a redesign of the course. It was a focused improvement to how the level feels while I continue iterating on the core prototype. I added a looping background track to give the room more identity, a short laser sound for the hazard trigger feedback, and a pickup cue when the shard is collected.

Those additions matter because they help the player read the space and the action quickly. The prototype still has the same route structure and progression logic, but the sound layer makes the training-environment idea feel more intentional and more complete in motion.

## Current calibration and finish pass

I also expanded the calibration loop to track two separate categories of player data: Stability and Risk. The cyan shards now represent Stability Data, and the orange shards represent Risk Data. The system collects both types independently, displays them in separate HUD lines, and requires a minimum of three total shards before the finish gate will accept the run.

The finish gate now gives a clear warning if the player reaches the end without enough calibration data, and a successful completion screen shows the final Stability and Risk totals. The behavior analysis then classifies the player's route as Stability-focused, Risk-focused, or Balanced. That is useful because the level is now more clearly functioning like a training or routing test rather than just a simple obstacle course.

This is one of the most important prototype steps because it gives the project an actual data and evaluative layer. The run now has a stronger concept behind it and a more readable end state, while still staying lightweight enough that I can keep iterating without overbuilding the system.

## Current tutorial and flow testing note

The complete beginning-to-end flow has been confirmed in Unity, including tutorial onboarding, gameplay, finish analysis, restarting the trial, and returning to the main menu. The insufficient-data warning was confirmed to disappear after a short delay without stopping gameplay, and restarting was confirmed to reset collected shard data. The tutorial beacon still rotates, audio changes from menu music to gameplay audio, and cursor behavior works across the menu, gameplay, pause, tutorial, and completion states. The final end-to-end test had no red Console errors.

## Remaining polish

The MVP loop is functional, but I still want to:

- refine the menu, tutorial, pause, and completion-panel layouts
- add laser warning lights or other visual/audio warning feedback
- continue balancing obstacle difficulty
- improve minor camera-framing issues if time permits
- test a standalone Windows build
- capture final screenshots and gameplay footage
- make only selective environmental and visual improvements that do not risk breaking the MVP

## What I am still figuring out

I’m continuing to learn how obstacle spacing, movement speed, and hazard feedback affect whether the route feels readable and fair. My next learning step is to explain the sine offset used for obstacle motion, write down what I predict it will do, and compare that prediction with the behavior in Unity.

The current calibration requirement is a minimum of three shards, and the finish analysis evaluates Stability and Risk totals. The full machine-learning adaptation layer remains a future direction rather than a completed feature.

## My learning goals

This is a learning project as much as a game project. I’m trying to get better at Unity level structure, C# scripting, movement patterns, and hazard readability. I want to keep the project honest and explainable, which is one reason I’m writing the README like this instead of pretending it is a perfectly polished progression.

I’m building the course one concept at a time, and I’m keeping the process visible because that is part of what I want this repository to show: not just the final object, but the decisions behind it, the learning that comes with it, and the honest state of the project as it changes.

This is not a claim that I have everything solved. It is just where the project stands right now, and I’m continuing from there.
