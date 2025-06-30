private static async Task ExecuteSubCommandOne(CommandContext context)
{
    await context.SendFeedback("Called /sub_command_one");
}