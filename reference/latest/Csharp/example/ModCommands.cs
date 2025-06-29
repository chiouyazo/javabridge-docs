// :::1
ItemHandler itemHandler = bridge.GetCommandHandler();
// :::1

// :::2
CommandBuilder testCommand = commandHandler.CreateCommand("test_command")
    .Executes(async context => await context.SendFeedback("Called /test_command"));
// :::2

// :::3
await context.GetSource().GetName();
// :::3

// :::4
await commandHandler.RegisterCommandAsync(testCommand);
// :::4

// :::5
CommandBuilder requiredCommand = commandHandler.CreateCommand("required_command")
			.Requires(async source => await source.HasPermissionLevel(1))
			.Executes(ExecuteRequiredCommand);
// :::5

// :::6
private static async Task ExecuteRequiredCommand(CommandContext context)
{
    await context.SendFeedback("Called /required_command");
}
// :::6

// :::7
CommandBuilder subCommandOne = commandHandler.CreateCommand("sub_command_one")
	        .Executes(ExecuteSubCommandOne);

CommandBuilder commandOne = commandHandler.CreateCommand("command_one")
            .AddSubCommand(subCommandOne);

await commandHandler.RegisterCommandAsync(commandOne);
// :::7

// :::8
private static async Task ExecuteSubCommandOne(CommandContext context)
{
    await context.SendFeedback("Called /sub_command_one");
}
// :::8

// :::9
CommandBuilder subCommandTwo = commandHandler.CreateCommand("sub_command_two")
        .Executes(ExecuteSubCommandTwo);

CommandBuilder commandTwo = commandHandler.CreateCommand("command_two")
        .Executes(ExecuteCommandTwo)
        .AddSubCommand(subCommandTwo);

await commandHandler.RegisterCommandAsync(commandTwo);
// :::9


// :::10
private static async Task ExecuteCommandTwo(CommandContext context)
{
    await context.SendFeedback("Called /command_two");
}

private static async Task ExecuteSubCommandTwo(CommandContext context)
{
    await context.SendFeedback("Called /sub_command_two");
}
// :::10

// :::11
CommandHandler clientCommandHandler = bridge.GetClientCommandHandler();
// :::11



// :::12
CommandBuilder commandWithArg = commandHandler.CreateCommand("command_with_arg")
        .Executes(ExecuteCommandWithArg)
        .AddArgument("value", "integer");

await commandHandler.RegisterCommandAsync(commandWithArg);
// :::12

// :::13
private static async Task ExecuteCommandWithArg(CommandContext context)
{
    // It can be safely assumed that this is a integer, otherwise minecraft wouldn't execute it.
    string value = context.Payload["value"];
    await context.SendFeedback($"Called /command_with_arg with value = {value}.");
}
// :::13


// :::14
CommandBuilder commandWithTwoArgs = commandHandler.CreateCommand("command_with_two_args")
        .Executes(ExecuteCommandWithArg)
        .AddArgument("value_one", "integer")
        .AddArgument("value_two", "integer", optional: true);

await commandHandler.RegisterCommandAsync(commandWithTwoArgs);
// :::14

// :::15
private static async Task ExecuteCommandWithMultipleArgs(CommandContext context)
{
    if (context.Payload.Count == 1)
    {
        // We can safely assume this exists, because it is not optional.
        string valueOne = context.Payload["value_one"];
        await context.SendFeedback($"Called /command_with_two_args with value one = {valueOne}.");
    }
    else
    {
        string valueOne = context.Payload["value_one"];
        string valueTwo = context.Payload["value_two"];
        await context.SendFeedback($"Called /command_with_two_args with value one = {valueOne} and value two = {valueTwo}.");
    }
}
// :::15


// :::16
CommandBuilder commandWithSuggestions = commandHandler.CreateCommand("command_with_suggestions")
        .AddArgument("entity", "string", false, "SUMMONABLE_ENTITIES")
        .Executes(ExecuteCommandWithSuggestions);

await commandHandler.RegisterCommandAsync(commandWithSuggestions);
// :::16

// :::17
private static async Task ExecuteCommandWithSuggestions(CommandContext context)
{
    string entityType = context.Payload["entity"];
    await context.SendFeedback($"Called /command_with_suggestions with entity {entityType}.");
}
// :::17


// :::18
commandHandler.RegisterSuggestionProvider("player_names", async (completion, ctx) =>
{
    // completion would be the string that the user has already typed in the chat. (Can be used to filter/sort)
    List<string> playerNames = await ctx.GetPlayerNames();
    
    return playerNames;
});
// :::18

// :::19
CommandBuilder commandWithCustomSuggestions = commandHandler.CreateCommand("command_with_custom_suggestions")
        .AddArgument("player_name", "string", false, "CUSTOM:player_names")
        .Executes(ExecuteCommandWithCustomSuggestions);

await commandHandler.RegisterCommandAsync(commandWithCustomSuggestions);
// :::19

// :::20
private static async Task ExecuteCommandWithCustomSuggestions(CommandContext context)
{
    string name = context.Payload["player_name"];
    await context.SendFeedback($"Called /command_with_custom_suggestions with value = {name}.");
}
// :::20