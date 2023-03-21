# SkulSeedMenu
Simple mod for "Skul: The Hero Slayer" that provides you with ability to change the world-generation seed value
<img width="802" alt="Preview" src="https://user-images.githubusercontent.com/45824078/226492985-8cf064a4-6a44-4fa3-8625-79fdbbffca27.png">

### Setup premise
`$(SkulFolder)` is a directory where the game is located on your PC

### Setup
1. Extract into `$(SkulFolder)/2020.3.34` (You will need to create a folder)
    - [unstripped Unity 2020.3.34 files](https://unity.bepinex.dev/libraries/2020.3.34.zip)
    - [unstripped CoreLibs 2020.3.34 files](https://unity.bepinex.dev/corlibs/2020.3.34.zip)
2. Extract into `$(SkulFolder)`
    - [BepInEx v5.4.21](https://github.com/BepInEx/BepInEx/releases/tag/v5.4.21)
3. In `$(SkulFolder)/doorstop.ini`
    - Set `dllSearchPathOverride=` to `dllSearchPathOverride=2020.3.34`
4. Download (or [build it yourself](#build-it-yourself)) the mod from ["Releases" page](https://github.com/limtis0/SkulSeedMenu/releases) and place it to `$(SkulFolder)/BepInEx/plugins`

### Build it yourself
Assuming you have .NET Framework 4.7.2 and Visual Studio installed
1. Clone the project into Visual Studio
2. NuGet packages should install automatically, if they didn't - do so
3. Add `Assembly-CSharp` and all `Plugins...` `Unity...` `UnityEngine...` .dll files from `$(SkulFolder)/SkulData/Managed/` to the references
4. Build the solution

# Compatibility
- [Skul: The Hero Slayer v1.7.0+](https://store.steampowered.com/news/app/1147560/view/5283318909430116714) (Built on [Unity 2020.3.34f1](https://unity.com/releases/editor/whats-new/2020.3.34); Should work for future releases if nothing drastically changes)
- [Harmony v2.2.2 (<v2.0f)](https://github.com/pardeike/Harmony/releases/tag/v2.2.2.0)
- [BepInEx v5.4.21 (v2.0f+)](https://github.com/BepInEx/BepInEx/releases/tag/v5.4.21)
