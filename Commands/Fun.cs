using System;
using System.Threading.Tasks;
using DSharpPlus.Entities;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using TuxBot.Utils;

namespace TuxBot.Commands
{
    public class Fun : BaseCommandModule
    {
        [Command("coinflip")]
        public async Task CoinFlip(CommandContext ctx)
        {
            await ctx.Channel.TriggerTypingAsync().ConfigureAwait(false);
            DiscordEmbedBuilder embed = new DiscordEmbedBuilder();
            int rNum = new Random().Next(1, 7);
            string result = "";
            switch(rNum)
            {
                case 1:
                case 3:
                case 5:
                    result = "Heads";
                    break;
                case 2:
                case 4:
                case 6:
                    result = "Tails";
                    break;
            }
            embed.Title = "Coin Flip";
            embed.Description = result;
            embed.Color = ColorUtils.GetRandomColor();
            await ctx.Channel.SendMessageAsync(embed: embed).ConfigureAwait(false);
        }

        [Command("echo")]
        public async Task Echo(CommandContext ctx, [RemainingText, Description("Phrase to make Tux say")] string phrase)
        {
            await ctx.Channel.TriggerTypingAsync().ConfigureAwait(false);
            DiscordEmbedBuilder embed = new DiscordEmbedBuilder();
            embed.Description = phrase;
            embed.Color = ColorUtils.GetRandomColor();
            await ctx.Channel.SendMessageAsync(embed: embed).ConfigureAwait(false);
        }

        [Command("poll")]
        public async Task Poll(CommandContext ctx, [RemainingText, Description("Question to ask")] string question)
        {
            await ctx.Channel.TriggerTypingAsync().ConfigureAwait(false);
            DiscordEmbedBuilder embed = new DiscordEmbedBuilder();
            embed.Title = "Poll";
            embed.AddField("Question", question);
            embed.Color = ColorUtils.GetRandomColor();
            DiscordMessage msg = await ctx.Channel.SendMessageAsync(embed: embed).ConfigureAwait(false);
            await msg.CreateReactionAsync(DiscordEmoji.FromUnicode("👍")).ConfigureAwait(false);
            await msg.CreateReactionAsync(DiscordEmoji.FromUnicode("👎")).ConfigureAwait(false);
        }
    }
}
