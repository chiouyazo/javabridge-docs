---
title: Command Suggestions
description: Learn how to suggest command argument values to users.
authors:
  - IMB11
  - chiouyazo
---

Minecraft has a powerful command suggestion system that's used in many places, such as the `/give` command. This system allows you to suggest values for command arguments to the user, which they can then select from - it's a great way to make your commands more user-friendly and ergonomic.

## Suggestion Providers {#suggestion-providers}

A `SuggestionProvider` is used to make a list of suggestions that will be sent to the client. A suggestion provider is a functional interface that takes a `CommandContext` and a `SuggestionBuilder` and returns some `Suggestions`. The `SuggestionProvider` returns a `CompletableFuture` as the suggestions may not be available immediately.

## Using Suggestion Providers {#using-suggestion-providers}

To use a suggestion provider, you can add the type string at the end of the method when adding a argument.
(This will later be converted into a enum)

::: code-group
<<< @/reference/latest/Csharp/example/Command/BuildCommandWithSuggestions.cs{c#} [C#]
<<< @/reference/latest/Cpp/example/Command/BuildCommandWithSuggestions.cs{c++} [C++]
:::

::: code-group
<<< @/reference/latest/Csharp/example/Command/ExecuteCommandWithSuggestions.cs{c#} [C#]
<<< @/reference/latest/Cpp/example/Command/ExecuteCommandWithSuggestions.cs{c++} [C++]
:::

## Built-in Suggestion Providers {#built-in-suggestion-providers}

There are a few built-in suggestion providers that you can use:

| Suggestion Provider                       | Description                                  |
| ----------------------------------------- | -------------------------------------------- |
| `SuggestionProviders.SUMMONABLE_ENTITIES` | Suggests all entities that can be summoned.  |
| `SuggestionProviders.AVAILABLE_SOUNDS`    | Suggests all sounds that can be played.      |
| `LootCommand.SUGGESTION_PROVIDER`         | Suggests all loot tables that are available. |
| `SuggestionProviders.ALL_BIOMES`          | Suggests all biomes that are available.      |

## Creating a Custom Suggestion Provider {#creating-a-custom-suggestion-provider}

If a built-in provider doesn't satisfy your needs, you can create your own suggestion provider.
To do this, you can register a SuggestionProvider using the `RegisterSuggestionProvider()` method in the command handler.

::: code-group
<<< @/reference/latest/Csharp/example/Command/RegisterSuggestionProvider.cs{c#} [C#]
<<< @/reference/latest/Cpp/example/Command/RegisterSuggestionProvider.cs{c++} [C++]
:::

To use this suggestion provider, you would simply pass the identifier with the prefix "CUSTOM:" into the registration of an argument.

::: code-group
<<< @/reference/latest/Csharp/example/Command/BuildCommandWithCustomSuggestions.cs{c#} [C#]
<<< @/reference/latest/Cpp/example/Command/BuildCommandWithCustomSuggestions.cs{c++} [C++]
:::

::: code-group
<<< @/reference/latest/Csharp/example/Command/ExecuteCommandWithCustomSuggestions.cs{c#} [C#]
<<< @/reference/latest/Cpp/example/Command/ExecuteCommandWithCustomSuggestions.cs{c++} [C++]
:::


Obviously, suggestion providers can be more complex, since they can also read the command context to provide suggestions based on the command's state - such as the arguments that have already been provided.

This could be in the form of reading the player's inventory and suggesting items, or entities that are nearby the player.
