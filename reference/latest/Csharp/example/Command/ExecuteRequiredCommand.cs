private static async Task ExecuteRequiredCommand(CommandContext context)
{
    await context.SendFeedback("Called /required_command");
}