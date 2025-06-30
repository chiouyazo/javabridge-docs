CommandBuilder commandWithArg = commandHandler.CreateCommand("command_with_arg")
        .Executes(ExecuteCommandWithArg)
        .AddArgument("value", "integer");

await commandHandler.RegisterCommandAsync(commandWithArg);