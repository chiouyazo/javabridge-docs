---
title: Command Arguments
description: Learn how to create commands with complex arguments.
authors:
  - FabricMC
  - chiouyazo
---

Arguments are used in most of the commands. Sometimes they can be optional, which means if you do not provide that
argument,
the command will also run. One node may have multiple argument types, but be aware that there is a possibility of
ambiguity, which should be avoided.

::: code-group
<<< @/reference/latest/Csharp/example/Command/Arguments/BuildCommandWithArg.cs{c#} [C#]
<<< @/reference/latest/Cpp/example/Command/Arguments/BuildCommandWithArg.cs{c++} [C++]
:::

::: code-group
<<< @/reference/latest/Csharp/example/Command/Arguments/ExecuteCommandWithArg.cs{c#} [C#]
<<< @/reference/latest/Cpp/example/Command/Arguments/ExecuteCommandWithArg.cs{c++} [C++]
:::

Available type strings (This will be converted into enums down the road):

- int/integer
- long
- float
- double
- bool/boolean
- string

Fallback: type of `StringArgumentType.word()`

In this case, after the command text `/command_with_arg`, you should type an integer. For example, if you
run `/command_with_arg 3`, you will get the feedback message:

> Called /command_with_arg with value = 3

If you type `/command_with_arg` without arguments, the command cannot be correctly parsed.

Then we add an optional second argument:

::: code-group
<<< @/reference/latest/Csharp/example/Command/Arguments/BuildCommandWithTwoArgs.cs{c#} [C#]
<<< @/reference/latest/Cpp/example/Command/Arguments/BuildCommandWithTwoArgs.cs{c++} [C++]
:::

::: code-group
<<< @/reference/latest/Csharp/example/Command/Arguments/ExecuteCommandWithMultipleArgs.cs{c#} [C#]
<<< @/reference/latest/Cpp/example/Command/Arguments/ExecuteCommandWithMultipleArgs.cs{c++} [C++]
:::

Now you can type one or two integers. If you give one integer, a feedback text with a single value is printed. If you
provide two integers, a feedback text with two values will be printed.

## Custom Argument Types {#custom-argument-types}

**Custom argument types are not yet available in the JavaBridge.**

<!-- If vanilla does not have the argument type you need, you can create your own. To do this, you need to create a class that inherits the `ArgumentType<T>` interface where `T` is the type of the argument. -->

<!-- 
You will need to implement the `parse` method, which will parse the input string into the desired type.

For example, you can create an argument type that parses a `BlockPos` from a string with the following format: `{x, y, z}`

@[code lang=java transcludeWith=:::1](@/reference/latest/src/main/java/com/example/docs/command/BlockPosArgumentType.java)

### Registering Custom Argument Types {#registering-custom-argument-types}

::: warning
You need to register the custom argument type on both the server and the client or else the command will not work!
:::

You can register your custom argument type in the `onInitialize` method of your [mod's initializer](./getting-started/project-structure#entrypoints) using the `ArgumentTypeRegistry` class:

@[code lang=java transcludeWith=:::register_custom_arg](@/reference/latest/src/main/java/com/example/docs/command/FabricDocsReferenceCommands.java)

### Using Custom Argument Types {#using-custom-argument-types}

We can use our custom argument type in a command - by passing an instance of it into the `.argument` method on the command builder.

@[code lang=java highlight={3} transcludeWith=:::custom_arg_command](@/reference/latest/src/main/java/com/example/docs/command/FabricDocsReferenceCommands.java)
@[code lang=java highlight={2} transcludeWith=:::execute_custom_arg_command](@/reference/latest/src/main/java/com/example/docs/command/FabricDocsReferenceCommands.java)

Running the command, we can test whether or not the argument type works:

![Invalid argument](/assets/develop/commands/custom-arguments_fail.png)

![Valid argument](/assets/develop/commands/custom-arguments_valid.png)

![Command result](/assets/develop/commands/custom-arguments_result.png) -->
