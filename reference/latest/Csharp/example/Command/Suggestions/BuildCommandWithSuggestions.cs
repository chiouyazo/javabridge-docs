CommandBuilder commandWithSuggestions = commandHandler.CreateCommand("command_with_suggestions")
        .AddArgument("entity", "string", false, "SUMMONABLE_ENTITIES")
        .Executes(ExecuteCommandWithSuggestions);

await commandHandler.RegisterCommandAsync(commandWithSuggestions);