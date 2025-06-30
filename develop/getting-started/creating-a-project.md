---
title: Creating a Project
description: A step-by-step guide on how to create a new mod project using the Fabric template mod generator.
authors:
  - Cactooz
  - IMB11
  - radstevee
  - chiouyazo
---

## Mod registration {#mod-registration}

For the JavaBridge to recognize your mod, you must ship a `.bridgeStartup` file.
The file should carry the same name as your mod.

If you want to provide assets, like textures with your mod, you should also create a `_assets` folder, which holds the same structure as a normal resource pack.

It's important to note that the `.bridgeStartup` file and _assets folder should have the same name.

Under `.minecraft/mods` you can either just put the `.bridgeStartup` file into the root, or create a seperate sub folder.

So your folder structure looks something like this

- .minecraft
  - mods
    - exammpleMod
      - exampleMod_assets
      - exampleMod.bridgeStartup


The `.bridgeStartup` file should contain the command to startup your mod with the current port (this might change in the future).

For example in C# it would be

```sh
dotnet run exampleMod.dll 63982
```

In python it might be something like

```sh
python3 exampleMod.py 63982
```