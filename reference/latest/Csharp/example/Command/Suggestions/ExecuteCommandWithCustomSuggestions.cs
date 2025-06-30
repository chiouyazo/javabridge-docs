private static async Task ExecuteCommandWithCustomSuggestions(CommandContext context)
{
    string name = context.Payload["player_name"];
    await context.SendFeedback($"Called /command_with_custom_suggestions with value = {name}.");
}