CommandBuilder requiredCommand = commandHandler.CreateCommand("required_command")
        .Requires(async source => await source.HasPermissionLevel(1))
        .Executes(ExecuteRequiredCommand);