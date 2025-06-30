CommandBuilder commandWithCustomSuggestions = commandHandler.CreateCommand("command_with_custom_suggestions")
        .AddArgument("player_name", "string", false, "CUSTOM:player_names")
        .Executes(ExecuteCommandWithCustomSuggestions);

await commandHandler.RegisterCommandAsync(commandWithCustomSuggestions);