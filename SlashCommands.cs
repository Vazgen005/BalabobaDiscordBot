using BalabobaDiscordBot.Api;
using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;

namespace BalabobaDiscordBot
{
    internal class SlashCommands : ApplicationCommandModule
    {
        [SlashCommand("BalabobIt", "Balabob something")]

        public static async Task BalabobIt(InteractionContext ctx,
            [ChoiceProvider(typeof(Categories))]
            [Option("Style", "Style of balabobing")] long intro,
            [Option("text", "Write something and Balaboba will continue")] string text
            )
        {
            await ctx.CreateResponseAsync(InteractionResponseType.DeferredChannelMessageWithSource);
            var data = await BalabobaRequests.GetBalabobaString(text, intro: intro);

            if (data.BadQuery == 1)
            {
                await ctx.EditResponseAsync(new DiscordWebhookBuilder().WithContent(
                    $"Balaboba doesn’t accept queries about sensitive topics, like politics or religion. People may take the generated text too seriously.\n" +
                    $"\nThe probability that a query contains a triggering or sensitive topic is determined by a neural network trained on random people’s estimates. It can overdo it or miss something."
                    ));
                return;
            }
            if (data.EmptyZeliboba <= 1)
            {
                await ctx.EditResponseAsync(new DiscordWebhookBuilder().WithContent("Sorry, Balaboba can’t come up with a text."));
                return;
            }
            if (data.Error == 1 || data.Text == "")
            {
                await ctx.EditResponseAsync(new DiscordWebhookBuilder().WithContent("Unknown error."));
                return;
            }

            await ctx.EditResponseAsync(new DiscordWebhookBuilder().WithContent($"**{data.Query}**{data.Text}"));
        }
    }
}
