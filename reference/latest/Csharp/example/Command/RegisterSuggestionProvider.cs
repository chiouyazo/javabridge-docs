commandHandler.RegisterSuggestionProvider("player_names", async (completion, ctx) =>
{
    // completion would be the string that the user has already typed in the chat. (Can be used to filter/sort)
    List<string> playerNames = await ctx.GetPlayerNames();
    
    return playerNames;
});