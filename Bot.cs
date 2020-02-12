using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using TuxBot.Commands;
using TuxBot.Events;

namespace TuxBot
{
    public class Bot
    {
        public static string Version { get; private set; }
        public static BotConfig Config { get; private set; }
        private DiscordClient client;
        private CommandsNextExtension commands;
        private List<string> prefixes;
        
        public Bot()
        {
            Version = "1.1.0";
            Console.Title = "Tux Bot";
            prefixes = new List<string>();
        }

        public static void Main(string[] args)
        {
            new Bot().Start(args);
        }

        public void Start(string[] args)
        {
            string configPath = "config.json";
            Console.Clear();
            Console.WriteLine("===Tux Bot===");
            Console.WriteLine($"Version: {Version}");
            if (File.Exists(configPath))
            {
                Config = JsonConvert.DeserializeObject<BotConfig>(File.ReadAllText(configPath));
                Console.WriteLine($"Token: {Config.Token}");
                Console.WriteLine($"Prefix: {Config.Prefix}");
            }
            else
            {
                Config = new BotConfig();
                Console.Write("Token: ");
                Config.Token = Console.ReadLine();
                Console.Write("Prefix: ");
                Config.Prefix = Console.ReadLine();
                string json = JsonConvert.SerializeObject(Config);
                File.WriteAllText(configPath, json);
            }
            Console.WriteLine("=============");
            prefixes.Add(Config.Prefix);
            DiscordAsync(args).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        private async Task DiscordAsync(string[] args)
        {
            client = new DiscordClient(new DiscordConfiguration
            {
                Token = Config.Token,
                TokenType = TokenType.Bot,
                AutoReconnect = true,
            });
            commands = client.UseCommandsNext(new CommandsNextConfiguration
            {
                StringPrefixes = prefixes,
                EnableDms = false,
                EnableMentionPrefix = true,
                CaseSensitive = false,
                EnableDefaultHelp  = false,
            });
            commands.RegisterCommands<Fun>();
            commands.RegisterCommands<General>();
            commands.RegisterCommands<Misc>();
            commands.RegisterCommands<Moderation>();
            commands.RegisterCommands<OSDistro>();
            client.Ready += BotEvents.Ready;
            client.GuildMemberAdded += GuildEvents.GuildMemberAdded;
            client.GuildMemberRemoved += GuildEvents.GuildMemberRemoved;
            commands.CommandErrored += CommandEvents.CommandErrored;
            await client.ConnectAsync();
            await Task.Delay(-1);
        }
    }
}
