CommandBuilder subCommandOne = commandHandler.CreateCommand("sub_command_one")
	        .Executes(ExecuteSubCommandOne);

CommandBuilder commandOne = commandHandler.CreateCommand("command_one")
            .AddSubCommand(subCommandOne);

await commandHandler.RegisterCommandAsync(commandOne);