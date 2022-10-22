using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;

namespace BalabobaDiscordBot.Api
{
    public class Categories : IChoiceProvider
    {
        public async Task<IEnumerable<DiscordApplicationCommandOptionChoice>> Provider()
        {
            var Choices = new List<DiscordApplicationCommandOptionChoice>();

            foreach (dynamic i in (await BalabobaRequests.GetBalabobaIntros("https://yandex.ru/lab/api/yalm/intros_eng")).Intros)
            {
                Choices.Add(new DiscordApplicationCommandOptionChoice(Convert.ToString(i[1]), i[0]));
            }

            foreach (dynamic i in (await BalabobaRequests.GetBalabobaIntros("https://yandex.ru/lab/api/yalm/intros")).Intros)
            {
                Choices.Add(new DiscordApplicationCommandOptionChoice($"{i[1]} (RU)", i[0]));
            }
            return Choices;
        }
    }
}
