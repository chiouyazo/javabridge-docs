---
title: Creating Commands
description: Create commands with complex arguments and actions.
authors:
  - Atakku
  - dicedpixels
  - haykam821
  - i509VCB
  - Juuxel
  - modmuss50
  - mschae23
  - natanfudge
  - Pyrofab
  - SolidBlock-cn
  - Technici4n
  - Treeways
  - xpple
  - chiouyazo
---

Creating commands can allow a mod developer to add functionality that can be used through a command. This tutorial will
teach you how to register commands and the general command structure of Brigadier.

<!-- ::: info
Brigadier is a command parser and dispatcher written by Mojang for Minecraft. It is a tree-based command library where
you build a tree of commands and arguments.

Brigadier is open-source: <https://github.com/Mojang/brigadier>
:::

## The `Command` Interface {#the-command-interface}

`com.mojang.brigadier.Command` is a functional interface, which runs some specific code, and throws a
`CommandSyntaxException` in certain cases. It has a generic type `S`, which defines the type of the _command source_.
The command
source provides some context in which a command was run. In Minecraft, the command source is typically a
`ServerCommandSource` which can represent a server, a command block, a remote connection (RCON), a player or an entity.

The single method in `Command`, `run(CommandContext<S>)` takes a `CommandContext<S>` as the sole parameter and returns
an integer. The command context holds your command source of `S` and allows you to obtain arguments, look at the parsed
command nodes and see the input used in this command.

Like other functional interfaces, it is usually used as a lambda or a method reference:

```java
Command<ServerCommandSource> command = context -> {
    return 0;
};
```

The integer can be considered the result of the command. Typically values less than or equal to zero mean a command has failed and will
do nothing. Positive values mean the command was successful and did something. Brigadier provides a constant to indicate
success; `Command#SINGLE_SUCCESS`.

### What Can the `ServerCommandSource` Do? {#what-can-the-servercommandsource-do}

A `ServerCommandSource` provides some additional implementation-specific context when a command is run. This includes
the
ability to get the entity that executed the command, the world the command was run in or the server the command was run
on.

You can access the command source from a command context by calling `getSource()` on the `CommandContext` instance.

```java
Command<ServerCommandSource> command = context -> {
    ServerCommandSource source = context.getSource();
    return 0;
};
``` -->

## Registering a Basic Command {#registering-a-basic-command}

### Building {#building-command}

Commands are registered within the `CommandHandler` provided by the Bridge.

@[code transcludeWith=:::1](@/reference/latest/Csharp/example/ModCommands.cs)

Commands should be registered on your mods startup. New commands cannot be registered during runtime and the command result will then return false.

Commands can be build fluently using the `CreateCommand()` method.

@[code transcludeWith=:::2](@/reference/latest/Csharp/example/ModCommands.cs)

The context is of type `CommandContext` and it provides access to the CommandSource, which in turn gives access to (nearly) all context that java would have too.

For example the player name that executed the command can be gotten by running:

@[code transcludeWith=:::3](@/reference/latest/Csharp/example/ModCommands.cs)

The CommandContext might vary depending on if the command is a client or server command. (e.g. the `NotInAnyWorld()` method is only available in server commands)

### Registration {#registering-command}

After a command was build, it has to be registered using the `RegisterCommandAsync` method.

@[code transcludeWith=:::4](@/reference/latest/Csharp/example/ModCommands.cs)

To execute this command, you must type `/test_command`, which is case-sensitive.

::: info
From this point onwards, we will be extracting the logic written within the lambda passed into `.execute()` builders into individual methods. We can then pass a method reference to `.execute()`. This is done for clarity.
:::

### Registration Environment {#registration-environment}

If desired, you can also make sure a command is only registered under some specific circumstances, for example, only in
the dedicated environment:

**The environment context is not yet available in the JavaBridge.**

<!-- @[code lang=java highlight={2} transcludeWith=:::dedicated_command](@/reference/latest/src/main/java/com/example/docs/command/FabricDocsReferenceCommands.java)
@[code lang=java transcludeWith=:::execute_dedicated_command](@/reference/latest/src/main/java/com/example/docs/command/FabricDocsReferenceCommands.java) -->

### Command Requirements {#command-requirements}

Let's say you have a command that you only want operators to be able to execute. This is where the `Requires()` method
comes into play. The `Requires()` method has one argument of a `Func<S>` which will supply a `ServerCommandSource`
to test with and determine if the `CommandSource` can execute the command.

@[code transcludeWith=:::5](@/reference/latest/Csharp/example/ModCommands.cs)

@[code transcludeWith=:::6](@/reference/latest/Csharp/example/ModCommands.cs)

This command will only execute if the source of the command is a level 2 operator at a minimum, including command
blocks. Otherwise, the command is not registered.

This has the side effect of not showing this command in tab completion to anyone who is not a level 2 operator. This is
also why you cannot tab-complete most commands when you do not enable cheats.

### Sub Commands {#sub-commands}

To add a sub command, you register the first literal node of the command normally. To have a sub command, you have to append the next literal node to the existing node.

@[code transcludeWith=:::7](@/reference/latest/Csharp/example/ModCommands.cs)

@[code transcludeWith=:::8](@/reference/latest/Csharp/example/ModCommands.cs)

Similar to arguments, sub command nodes can also be set optional. In the following case, both `/command_two`
and `/command_two sub_command_two` will be valid.

@[code transcludeWith=:::9](@/reference/latest/Csharp/example/ModCommands.cs)

@[code transcludeWith=:::10](@/reference/latest/Csharp/example/ModCommands.cs)

## Client Commands {#client-commands}

Client commands can be registered almost identically, but instead you have to get the client `CommandHandler`.

@[code transcludeWith=:::11](@/reference/latest/Csharp/example/ModCommands.cs)

## Command Redirects {#command-redirects}

Command redirects - also known as aliases - are a way to redirect the functionality of one command to another. This is useful for when you want to change the name of a command, but still want to support the old name.

**Command redirects are not yet available in the JavaBridge.**
<!-- ::: warning
Brigadier [will only redirect command nodes with arguments](https://github.com/Mojang/brigadier/issues/46). If you want to redirect a command node without arguments, provide an `.executes()` builder with a reference to the same logic as outlined in the example.
:::

@[code lang=java transcludeWith=:::redirect_command](@/reference/latest/src/main/java/com/example/docs/command/FabricDocsReferenceCommands.java)
@[code lang=java transcludeWith=:::execute_redirected_by](@/reference/latest/src/main/java/com/example/docs/command/FabricDocsReferenceCommands.java) -->