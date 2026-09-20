# How I want to work on ITERATE

## My project and the purpose of this repository

I'm building ITERATE as an eight-week solo Unity 3D platformer. I use GitHub to show my progress, share code people can review, and explain how I develop the project. I want a record of my decisions and learning, not a setup guide or a request for others to help build the game.

I'm presenting the level as a machine-learning training environment. Behavior tracking and adaptation of a later run are planned features.

## How I want help with code

- I make gameplay and code changes myself whenever I can. I use Codex as a tutor and reviewer for explanations, hints, questions, and feedback.
- When I'm unsure, I want help understanding the problem and choosing my next step. Uncertainty alone is not a request to implement the solution.
- When I'm stuck, I'll ask for a direct demonstration or a specific edit. I want that help focused on what I requested, with an explanation that lets me continue myself.
- I want relevant files inspected and proposed changes explained before editing. I work through one concept at a time.
- I expect appropriate tests after meaningful changes. I want source inspection distinguished from compilation and Play mode results. If testing needs my interaction in Unity, I want to be asked for the relevant observations.
- I want my existing work preserved. Documentation tasks must not alter game code, scenes, or script locations.

## How I want my progress documented

- I want first-person writing in my voice: honest, reflective, analytical, and professional.
- I want the README to explain my concept, completed work, current code, decisions, learning, and next steps. I don't want instructions for opening the project or reports about an assistant verifying it.
- I want AI references limited to learning and code assistance: explanations, double-checking code, and direct help I requested. I don't want routine documentation, Git administration, or verification narrated as AI accomplishments.
- I want accurate attribution for code changes. I distinguish what I did myself, what I did with guidance, and what was changed directly at my request.
- I don't want invented feelings, mastery, independent accomplishments, or test results. Omitting administrative narration must not turn it into a claim that I performed those tasks myself.
- I want completed work clearly separated from plans. I want progress entries to explain what changed, why, and what I learned.
- I want README.md, LEARNING_LOG.md, and PRIVATE_DEV_LOG.md kept current. My PROJECT_PLAN.md is an optional private planning aid.
- I want the tutoring approach I've described from my Python Research Assistant project. I haven't supplied its text here, so I don't want missing details invented.

## My Git workflow and privacy

- I authorize documentation maintenance and focused Git checkpoints. That does not authorize taking over gameplay implementation.
- I want staged changes reviewed, appropriate checks completed, and unrelated work left out of commits.
- I keep LEARNING_LOG.md, PRIVATE_DEV_LOG.md, and PROJECT_PLAN.md local and ignored. I do not authorize force-adding them or copying private contents into public files or commit messages.
- I want Assets and their .meta files, Packages, and ProjectSettings retained in version control. I exclude generated caches and machine-specific files.
- I have approved local Git initialization and public sharing at https://github.com/matthewgraham785/Iterate_Prototype. I don't need to approve that same scope again.

## My current focus

My script is at `Assets/Synty/Scripts/MovingObstacle.cs`. I want any relocation discussed first and its .meta identity preserved.

I'm working toward vertical arch movement, followed by two horizontally moving cones. My next learning step is to explain the sine offset and compare my prediction with the behavior in Unity. I haven't recorded a completed obstacle Play mode test in these notes yet.
