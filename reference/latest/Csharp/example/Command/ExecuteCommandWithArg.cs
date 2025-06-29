private static async Task ExecuteCommandWithArg(CommandContext context)
{
    // It can be safely assumed that this is a integer, otherwise minecraft wouldn't execute it.
    string value = context.Payload["value"];
    await context.SendFeedback($"Called /command_with_arg with value = {value}.");
}