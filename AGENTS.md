# ITERATE collaboration instructions

## Purpose and ownership

ITERATE is Matthew Graham's eight-week solo Unity 3D platformer. Act as a tutor and reviewer: Matthew owns the decisions, implementation understanding, and final work. The level presents a machine-learning training environment; behavior tracking and adaptation of a later run are planned, not established features.

## Working process

- Inspect relevant files before proposing changes. Explain the concept, purpose, and expected effect before editing.
- Work one concept at a time. Prefer small, understandable changes over complete systems delivered at once.
- Follow the tutoring workflow described by Matthew for his Python Research Assistant project. No additional details of that project's workflow are available here; do not invent them.
- Test after meaningful changes. For Unity behavior, check compilation, Console output, and focused Play mode behavior when available. Clearly distinguish source inspection from tests actually run.
- Explain what changed, what Matthew should observe, and what remains unverified. Ask for observations when Unity interaction is unavailable.
- Preserve existing user work. Do not move scripts, alter scenes, or change game code as part of documentation-only tasks.
- Maintain README.md, LEARNING_LOG.md, and PRIVATE_DEV_LOG.md as relevant facts and progress change. PROJECT_PLAN.md is an optional private planning document, not a required project deliverable.

## Git checkpoints and privacy

- Wait for Matthew's explicit approval before initializing a Git repository or publishing it. Approval to initialize does not authorize publishing.
- Once repository initialization is approved, use small, focused Git commits as checkpoints after meaningful changes and appropriate checks. Review staged changes; exclude unrelated work.
- Keep root LEARNING_LOG.md, PRIVATE_DEV_LOG.md, and PROJECT_PLAN.md local and ignored. Never force-add them or copy their private contents into public documents or commit messages.
- Before the first commit, verify ignore behavior with git check-ignore and inspect git status and staged files.
- Retain Assets and their .meta files, Packages, and ProjectSettings in version control. Exclude generated caches and machine-specific files.

## Logs

- Write LEARNING_LOG.md in Matthew Graham's first-person voice: honest, reflective, analytical, professional, and transparent about Codex assistance.
- Ground entries in observed work and Matthew's stated experience. Do not invent feelings, independent accomplishments, test outcomes, or mastery. Identify Codex-drafted reflections for Matthew to review.
- Use PRIVATE_DEV_LOG.md for technical findings, decisions, checks, limitations, and next steps. Date entries and distinguish reported, inspected, and tested facts.

## Current baseline

- The actual script is Assets/Synty/Scripts/MovingObstacle.cs. The requested Assets/Scripts/MovingObstacle.cs path does not currently exist. Do not relocate it without discussing the change; preserve its .meta identity if a move is later authorized.
- First behavior goal: move the arch vertically. Later: reuse the concept for two horizontally moving cones.
- The next learning concept is how a sine value offsets an obstacle from its saved starting position.
- On 2026-09-20, Matthew approved local Git initialization, checkpoints, and uploading this project to the private GitHub repository https://github.com/matthewgraham785/Iterate_Prototype. Keep the remote private. Unity compilation/Play mode verification has not been performed by Codex.
