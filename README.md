# Tetris 2D

Tetris 2D is an offline C# project built with Raylib-cs and targeting .NET 10. It is structured as a small object-oriented game prototype with image, audio, and UI assets already included in the repository.

## Features

- Classic Tetris-style falling blocks
- Separate block classes for each piece type
- Asset-based rendering for blocks, UI, background, and audio
- Basic project structure ready for game logic, board handling, and UI layers

## Project Structure

- `src/` - C# source files for the game
- `assets/` - images, sound effects, music, and UI art
- `docs/` - extra project data and reference files
- `Makefile` - convenience commands for build and run

## Controls

The input system is still being developed, but the intended controls are:

- `Left` / `Right` - move the active piece
- `Down` - soft drop
- `Space` - hard drop
- `Up` or `X` - rotate clockwise
- `Z` - rotate counterclockwise
- `C` or `Left Shift` - hold piece
- `P` or `Esc` - pause
- `M` - mute or unmute audio
- `N` - switch background music
- `Enter` - start or restart

## Build and Run

Make sure you have the .NET 10 SDK installed.

### Using Make

```bash
make build
make run
make clean
```

### Using dotnet directly

```bash
dotnet build -c Release
dotnet run -c Release
```

## CI/CD

This repository uses GitHub Actions:

- `CI` runs on every push to `main` and on pull requests targeting `main`
- `CD` runs when a tag that starts with `v` is pushed, builds a Windows release package, and publishes it as a GitHub Release asset

## Notes

- `make run` will build the project before launching it.
- The game logic is still in progress, so some classes are currently placeholders.
- The project uses Raylib-cs for rendering and window management.

## License

This project is licensed under the MIT License. See [LICENSE](LICENSE) for details.
