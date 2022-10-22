using DSharpPlus;
using DSharpPlus.SlashCommands;

namespace BalabobaDiscordBot
{
    class Program
    {
        static void Main()
        {
            MainAsync().GetAwaiter().GetResult();
        }

        static async Task MainAsync()
        {
            string EnvironmentVar = "BalabobaBotDiscordToken";

            var token = System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform.Windows)
                        ? Environment.GetEnvironmentVariable(EnvironmentVar, EnvironmentVariableTarget.User)
                        : Environment.GetEnvironmentVariable(EnvironmentVar);

            if (token == null)
            {
                Console.WriteLine($"{EnvironmentVar} environment variable is not set");
                return;
            }

            var client = new DiscordClient(new DiscordConfiguration()
            {
                Token = token,
                AutoReconnect = true,
                TokenType = TokenType.Bot
            });

            var commands = client.UseSlashCommands();

            commands.RegisterCommands<SlashCommands>();

            await client.ConnectAsync();
            await Task.Delay(-1);
        }
    }
}