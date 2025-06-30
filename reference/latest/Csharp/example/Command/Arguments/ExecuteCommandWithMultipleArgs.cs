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