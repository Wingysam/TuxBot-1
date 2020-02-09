using System;
using System.Threading;
using System.Threading.Tasks;
using DSharpPlus.Entities;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using TuxBot.Utils;
using System.Diagnostics;

namespace TuxBot.Commands
{
    public class Misc
    {
        [Command("ping")]
        public async Task Ping(CommandContext ctx)
        {
            await ctx.Channel.TriggerTypingAsync().ConfigureAwait(false);
            DiscordEmbedBuilder embed = new DiscordEmbedBuilder();
            embed.Title = "Ping";
            embed.AddField("Pong!", $"Response Time: {ctx.Client.Ping} ms");
            embed.Color = ColorUtils.GetRandomColor();
            await ctx.Channel.SendMessageAsync(embed: embed).ConfigureAwait(false);
        }

        [Command("stop")]
        public async Task Stop(CommandContext ctx)
        {
            await ctx.Channel.TriggerTypingAsync().ConfigureAwait(false);
            DiscordEmbedBuilder embed = new DiscordEmbedBuilder();
            if (ctx.Member == ctx.Guild.Owner)
            {
                embed.Title = "Shutdown";
                embed.Description = "Tux has shutdown";
                embed.Color = ColorUtils.GetRandomColor();
                await ctx.Channel.SendMessageAsync(embed: embed).ConfigureAwait(false);
                Thread.Sleep(500);
                Environment.Exit(0);
            }
            else
            {
                embed.Title = "Error";
                embed.AddField("Invalid Permissions", "You must be the server owner to run this command");
                embed.Color = DiscordColor.Red;
                await ctx.Channel.TriggerTypingAsync().ConfigureAwait(false);
                await ctx.Channel.SendMessageAsync(embed: embed).ConfigureAwait(false);
            }
        }

        [Command("uptime")]
        public async Task Uptime(CommandContext ctx)
        {
            await ctx.Channel.TriggerTypingAsync().ConfigureAwait(false);
            DiscordEmbedBuilder embed = new DiscordEmbedBuilder();
            embed.Title = "Uptime";
            TimeSpan uptime = DateTime.UtcNow - Process.GetCurrentProcess().StartTime.ToUniversalTime();
            embed.Description = String.Format("{0:00}:{1:00}:{2:00}", uptime.Hours, uptime.Minutes, uptime.Seconds);
            embed.Color = ColorUtils.GetRandomColor();
            await ctx.Channel.SendMessageAsync(embed: embed).ConfigureAwait(false);
        }
    }
}
