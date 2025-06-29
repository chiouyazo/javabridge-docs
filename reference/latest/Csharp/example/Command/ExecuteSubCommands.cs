private static async Task ExecuteCommandTwo(CommandContext context)
{
    await context.SendFeedback("Called /command_two");
}

private static async Task ExecuteSubCommandTwo(CommandContext context)
{
    await context.SendFeedback("Called /sub_command_two");
}