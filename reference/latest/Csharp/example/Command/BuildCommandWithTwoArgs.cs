CommandBuilder commandWithTwoArgs = commandHandler.CreateCommand("command_with_two_args")
        .Executes(ExecuteCommandWithArg)
        .AddArgument("value_one", "integer")
        .AddArgument("value_two", "integer", optional: true);

await commandHandler.RegisterCommandAsync(commandWithTwoArgs);