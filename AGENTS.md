# How I want to work on ITERATE

## My project and ownership

I'm building ITERATE as an eight-week solo Unity 3D platformer. I want Codex to act as a tutor and reviewer. I remain responsible for my decisions, my understanding of the implementation, and the final work.

I'm presenting the level as a machine-learning training environment. Behavior tracking and adaptation of a later run are planned features, not completed systems.

## My working process

- I want Codex to inspect relevant files and explain the concept, purpose, and expected effect before editing.
- I want to work on one concept at a time, through small changes I can understand and review.
- I want the tutoring workflow I've described from my Python Research Assistant project. I haven't provided that project's full instructions or writing samples here, so I don't want missing details invented.
- I expect tests after meaningful changes. For Unity behavior, that means compilation, Console checks, and focused Play mode observation when available. I want source inspection distinguished from tests actually run.
- I want explanations of what changed, what I should observe, and what remains unverified. If Codex can't interact with Unity, I want it to ask me for the observations needed to continue.
- I want my existing work preserved. Documentation tasks must not move scripts, alter scenes, or change game code.
- I want README.md, LEARNING_LOG.md, and PRIVATE_DEV_LOG.md maintained as the project develops. My PROJECT_PLAN.md is an optional private planning document, not a required deliverable.

## My Git checkpoints and privacy

- I require my approval before initializing or publishing a repository. My current approvals are recorded below and do not need to be requested again for the same scope.
- I want small, focused commits after meaningful changes and appropriate checks. I expect staged changes to be reviewed and unrelated work excluded.
- I keep LEARNING_LOG.md, PRIVATE_DEV_LOG.md, and PROJECT_PLAN.md local and ignored. I do not authorize force-adding them or copying their private contents into public documentation or commit messages.
- I expect ignore rules and staged files to be checked before private material could enter a commit.
- I want Assets and their .meta files, Packages, and ProjectSettings retained in version control. I exclude generated caches and machine-specific files.

## My writing and logs

- I want my project documentation written in my first-person voice: honest, reflective, analytical, professional, and clear about Codex assistance.
- I want reflections grounded in my stated experience and the work actually observed. I do not want invented feelings, claims of independent accomplishment, test results, or mastery.
- I want Codex-drafted reflections identified for my review. First-person wording must not turn Codex's actions into claims that I performed them independently.
- I use PRIVATE_DEV_LOG.md to record technical findings, decisions, checks, limitations, and next steps. I want dated entries that distinguish what I reported, what Codex inspected, and what was tested.

## My current baseline

- My script is at `Assets/Synty/Scripts/MovingObstacle.cs`. I originally requested `Assets/Scripts/MovingObstacle.cs`, which does not exist. I want any relocation discussed first and the script's .meta identity preserved if I authorize a move.
- My first behavior goal is vertical arch movement. After that, I want to reuse the concept for two horizontally moving cones.
- My next learning step is to explain how a sine value offsets an obstacle from its saved starting position, then check that prediction in Unity.
- On 2026-09-20, I approved local Git initialization and checkpoints. I then requested public visibility for https://github.com/matthewgraham785/Iterate_Prototype so I can share it. This replaces my earlier preference for a private repository. My personal logs and planning remain local and ignored.
- I have not supplied a verified obstacle Play mode result in this conversation, and Codex has not run Unity compilation or gameplay checks.
