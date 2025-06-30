CommandBuilder subCommandTwo = commandHandler.CreateCommand("sub_command_two")
        .Executes(ExecuteSubCommandTwo);

CommandBuilder commandTwo = commandHandler.CreateCommand("command_two")
        .Executes(ExecuteCommandTwo)
        .AddSubCommand(subCommandTwo);

await commandHandler.RegisterCommandAsync(commandTwo);