private static async Task ExecuteCommandWithSuggestions(CommandContext context)
{
    string entityType = context.Payload["entity"];
    await context.SendFeedback($"Called /command_with_suggestions with entity {entityType}.");
}