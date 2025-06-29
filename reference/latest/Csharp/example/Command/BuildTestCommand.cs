CommandBuilder testCommand = commandHandler.CreateCommand("test_command")
    .Executes(async context => await context.SendFeedback("Called /test_command"));