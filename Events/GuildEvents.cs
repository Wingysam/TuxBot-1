using System.Threading.Tasks;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using TuxBot.Utils;

namespace TuxBot.Events
{
    public static class GuildEvents
    {
        public static async Task GuildMemberAdded(GuildMemberAddEventArgs args)
        {
            DiscordEmbedBuilder embed = new DiscordEmbedBuilder();
            DiscordChannel joinChannel = args.Guild.GetChannelByName("join-leave");
            DiscordChannel verifyChanel = args.Guild.GetChannelByName("verify");
            await joinChannel.TriggerTypingAsync().ConfigureAwait(false);
            embed.Title = "New Member Joined";
            embed.Description = $"Welcome {args.Member.Mention} to The Tech Community! This server has a verification system. Go to {verifyChanel.Mention} and type `!verify`";
            embed.Footer = new DiscordEmbedBuilder.EmbedFooter()
            {
                Text = args.Member.Username,
                IconUrl = args.Member.AvatarUrl
            };
            embed.Color = ColorUtils.GetRandomColor();
            await joinChannel.SendMessageAsync(embed: embed).ConfigureAwait(false);
        }

        public static async Task GuildMemberRemoved(GuildMemberRemoveEventArgs args)
        {
            DiscordEmbedBuilder embed = new DiscordEmbedBuilder();
            DiscordChannel leaveChannel = args.Guild.GetChannelByName("join-leave");
            await leaveChannel.TriggerTypingAsync().ConfigureAwait(false);
            embed.Title = "Member Left";
            embed.Description = $"{args.Member.Mention} has left. Goodbye";
            embed.Footer = new DiscordEmbedBuilder.EmbedFooter()
            {
                Text = args.Member.Username,
                IconUrl = args.Member.AvatarUrl
            };
            embed.Color = ColorUtils.GetRandomColor();
            await leaveChannel.SendMessageAsync(embed: embed).ConfigureAwait(false);
        }

        public static async Task MessageDeleted(MessageDeleteEventArgs args)
        {
            DiscordEmbedBuilder embed = new DiscordEmbedBuilder();
            DiscordChannel logChannel = args.Guild.GetChannelByName("tux-logs");
            await logChannel.TriggerTypingAsync().ConfigureAwait(false);
            embed.Title = "Message Deleted";
            embed.AddField("Message", args.Message.Content);
            embed.AddField("Author", args.Message.Author.Mention);
            embed.Color = ColorUtils.GetRandomColor();
            await logChannel.SendMessageAsync(embed: embed).ConfigureAwait(false);
        }

        public static async Task MessageUpdated(MessageUpdateEventArgs args)
        {
            DiscordEmbedBuilder embed = new DiscordEmbedBuilder();
            DiscordChannel logChannel = args.Guild.GetChannelByName("tux-logs");
            await logChannel.TriggerTypingAsync().ConfigureAwait(false);
            embed.Title = "Message Updated";
            embed.AddField("Old Message", args.MessageBefore.Content);
            embed.AddField("Updated Message", args.Message.Content);
            embed.AddField("Author", args.Message.Author.Mention);
            embed.Color = ColorUtils.GetRandomColor();
            await logChannel.SendMessageAsync(embed: embed).ConfigureAwait(false);
        }
    }
}
