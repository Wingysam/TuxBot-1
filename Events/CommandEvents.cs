using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Exceptions;
using DSharpPlus.Entities;

namespace TuxBot.Events
{
    public class CommandEvents
    {
        public static async Task CommandErrored(CommandErrorEventArgs e)
        {
            await e.Context.Channel.TriggerTypingAsync().ConfigureAwait(false);
            DiscordEmbedBuilder embed = new DiscordEmbedBuilder();
            if(e.Exception is CommandNotFoundException)
            {
                embed.Title = "Error";
                embed.AddField("Invalid Command", "Please check help for available commands");
                embed.Color = DiscordColor.Red;
            }
            else
            {
                embed.Title = "Error";
                embed.AddField("Command Exception", "Please make sure all arguments are provided correctly and you have valid permissions");
                embed.Color = DiscordColor.Red;
            }
            await e.Context.Channel.SendMessageAsync(embed: embed).ConfigureAwait(false);
        }
    }
}
