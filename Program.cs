using Discord;
using Discord.WebSocket;
using System;
using System.Threading.Tasks;

namespace DemoBot
{
    public class Program
    {
        private DiscordSocketClient _client;
        private string _token = "meu-token-discord";

        public static async Task Main(string[] args) => await new Program().RunBotAsync();

        public async Task RunBotAsync()
        {
            _client = new DiscordSocketClient(new DiscordSocketConfig
            {
                GatewayIntents = GatewayIntents.Guilds |
                                 GatewayIntents.GuildMessages |
                                 GatewayIntents.MessageContent
            });

            _client.Log += Log;

            _client.MessageReceived += HandleCommandAsync;

            await _client.LoginAsync(TokenType.Bot, token: _token);

            await _client.StartAsync();

            await Task.Delay(-1);
        }

        private Task Log(LogMessage message)
        {
            Console.WriteLine(message);
            return Task.CompletedTask;
        }

        private async Task HandleCommandAsync(SocketMessage message)
        {
            if (message.Author.IsBot) return;

            if (message.Content.ToLower() == "!ping")
            {
                await message.Channel.SendMessageAsync("Pong! 🏓");
            }
            if (message.Content.ToLower() == "!magia")
            {
                await message.Channel.SendMessageAsync("Os susurros dizem que você busca poder...mas você tem certeza que pode pagar o preço ? - 🐱");
            }
        }
    }
}