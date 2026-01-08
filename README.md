# MinecraftAuto

A Windows desktop application (WPF, .NET 8) for automating mouse actions in Minecraft, featuring preset-based auto-clicking, window binding, and global hotkeys.

## Features

- **Preset-based automation:** Choose from built-in presets like "Mouse Clicks" and "Concrete" for different automation scenarios.
- **Window binding:** Bind automation to a specific Minecraft window using a hotkey.
- **Global hotkeys:** Start/stop automation and bind to windows using F8/F9.
- **Single-file executable:** Download and run without installing .NET separately.

## Installation

1. Go to the [GitHub Releases](https://github.com/JohnRamberger/MinecraftAuto) page.
2. Download the latest `MinecraftAuto-x64.exe` or `MinecraftAuto-x86.exe` from the release assets.
3. Run the downloaded `.exe` file.

> **Note:** No installation required. The app is self-contained.

## Usage

1. **Start MinecraftAuto** and your Minecraft client.
2. **Bind to the Minecraft window:**  
   - Focus the Minecraft window.
   - Press `F9` in MinecraftAuto to bind.
3. **Select a preset:**  
   - Choose a preset (e.g., "Mouse Clicks", "Concrete") from the dropdown.
   - Adjust settings if needed.
4. **Start/Stop automation:**  
   - Press `F8` to toggle the auto-clicker. You don't need to be focused on Minecraft (can be "alt-tabbed").

## Building from Source

1. Install [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0).
2. Clone this repository.
3. Build and publish for your platform:

   