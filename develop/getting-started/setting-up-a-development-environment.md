---
title: Setting up a Development Environment
description: A step-by-step guide on how to set up a development environment to create mods using Fabric.
authors:
  - 2xsaiko
  - Andrew6rant
  - asiekierka
  - Daomephsta
  - falseresync
  - IMB11
  - liach
  - mkpoli
  - modmuss50
  - natanfudge
  - SolidBlock-cn
  - TelepathicGrunt
  - chiouyazo
authors-nogithub:
  - siglong
---

To start developing mods with Fabric, you will need to set up a development environment using IntelliJ IDEA.
To start developing mods using the JavaBridge, you will need to have set up a development environment and installed the ModHost package. (depending on your programming language)

## General {#general}

Each ModHost should have a slim example project, please refer to it on how to set your project up correctly.

You will also need to listen to the port from the startup arguments.

Currently this is set staticly to 63982, but it might be dynamically changed again in the future.

## C# {#csharp}

To develop mods using C#, you will need to install the ModHost.CSharp nuget package. (Not available yet)

_Since the nuget package is not available yet, instead pull the [ModHost.CSharp](https://github.com/chiouyazo/ModHost.CSharp) repo, and copy the core project into your project._

After installing the package, you will need to listen for the port, and then initialize the `ModHostBridge` class with your mod name.

```C#
public static async Task Main(string[] args)
{
  if (args.Length == 0)
  {
    Console.WriteLine("Port argument required.");
    return;
  }

  if (!int.TryParse(args[0], out int port))
  {
    Console.WriteLine("Valid port required.");
    return;
  }

  ModHostBridge bridge = new ModHostBridge(port, "Your mod name");
}
```

And that is pretty much already it.
From this point on you can refer to other guides on how to e.g. register commands.
The ModHostBridge will do everything else neccessary in the background.