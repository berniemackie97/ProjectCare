# ProjectCare - temporary project name until we decide a game name

This document is subject to and more than likely will change as time goes on, as we develop for this we should also try to update this document whenever it is applicable

Made with Godot 4.5 Mono (.NET/C#)

## Stack / versions

- Godot **4.5** (The .NET build)
- .NET SDK **8.X**

## Repo structure

/art
/design
/docs
/game
/tools

### Godot project layout

/Scenes
/Scripts
/Tiles
/UI

## Dev setup

open the /game folder as the Godot project in Godot when importing the project

Inside the Godot editor make sure to check that the Main Scene is set to Scenes/Main.tscn (if you run into any issues related to the scene)

## Scene / map policy

- Current tile size set to 64x32 (need to find out what works best with the artist)
- Enable Y Sort on every TimeMapLayer (Currently only have "Ground")

## UI policy

- All UI should be under UIRoot

## Code Practices

- Avoid heavy script files, try to keep files focused small and single responsibility

## Git & Workflow

- Default branch: **dev** (protected)
- branches: dev / staging / production
- Staging: release candidate branch (only should receive merge prs from dev when dev is at stable stages)
- Shouldnt need to explain what the prod branch is for
- PRs:
  - 1 reviewer minimum.
  - keep PRs task orientated, and focused (no giant unfocused prs)
  - include a bullet point commit with your changes and how to test your changes

## Large files

- Use Git LSF for binaries/textures/audio/fonts/etc
- Dont commit working files in /art without LSF tracked.

## Troubleshooting

- Scene times can spawn late, to remedy this we can attach a small script to the layer that calls "UpdateInternals()" (existing ground layer has this)

## License

Internal WIP, Not public. Not for distribution, also not protected. If you come across this project and you are not meant to have this, what ever comes from your use of this software is your own responsibility.
