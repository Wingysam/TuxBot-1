using System;
using System.Threading.Tasks;
using DSharpPlus.Entities;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using TuxBot.Utils;

namespace TuxBot.Commands
{
    public class General : BaseCommandModule
    {
        [Command("changelog")]
        public async Task Changelog(CommandContext ctx)
        {
            await ctx.Channel.TriggerTypingAsync().ConfigureAwait(false);
            DiscordEmbedBuilder embed = new DiscordEmbedBuilder();
            embed.WithAuthor("Tux Changelog", null, ctx.Guild.IconUrl);
            embed.AddField("Current Version", Bot.Version);
            embed.AddField("Added Message Logs", "Tux now logs when a message is updated or deleted");
            embed.AddField("Improved Logging", "Improved current logs");
            embed.AddField("Addrole and Removerole Fix", "Fixed issue where the addrole and removerole effected the message author and not the pinged user");
            embed.AddField("Whois Fix", "Fixed issue where whois command didn't work if pinged member had no nickname");
            embed.Color = ColorUtils.GetRandomColor();
            await ctx.Channel.SendMessageAsync(embed: embed).ConfigureAwait(false);
        }

        [Command("d")]
        public async Task D(CommandContext ctx, [RemainingText]string args)
        {
            await Task.CompletedTask;
        }

        [Command("help")]
        public async Task Help(CommandContext ctx)
        {
            DiscordEmbedBuilder embed = new DiscordEmbedBuilder();
            string general = "`changelog` ~ Shows the new features of the current version" +
                "\n`help` ~ Shows a list of available commands" +
                "\n`info` ~ Shows info about the bot and server" +
                "\n`invite` ~ Shows The Tech Community's invite link" +
                "\n`roleinfo` ~ Shows the number of users in each role in the server" +
                "\n`rules` ~ Shows the rules of the server" +
                "\n`source` ~ Shows the link to Tux's source code" +
                "\n`suggest <Suggestion>` ~ Adds your suggestion to the suggestion channel" +
                "\n`verify` ~ Verifies the user who uses the command" +
                "\n`whois <@User>` ~ Shows info about the pinged user";
            string osdistro = "`android` ~ Get the Android role" +
                "\n`arch` ~ Get the Arch role" +
                "\n`bsd` ~ Get the BSD role" +
                "\n`centos` ~ Get the CentOS role" +
                "\n`debian` ~ Get the Debian role" +
                "\n`fedora` ~ Get the Fedora role" +
                "\n`gentoo` ~ Get the Gentoo role" +
                "\n`macos` ~ Get the macOS role" +
                "\n`manjaro` ~ Get the Manjaro role" +
                "\n`other` ~ Get the Other role" +
                "\n`redhat` ~ Get the RedHat role" +
                "\n`suse` ~ Get the Suse role" +
                "\n`ubuntu` ~ Get the Ubuntu role" +
                "\n`windows` ~ Get the Windows role";
            string fun = "`coinflip` ~ Heads or Tails?" +
                "\n`echo <Phrase>` ~ Make Tux look like he is saying something" +
                "\n`poll <Question>` ~ Asks a yes or no poll";
            string mod = "`addrole <@User> <Role Name>` ~ Adds the given role to the pinged user" +
                "\n`ban <@User> <Reason>` ~ Bans the pinged user for the given reason" +
                "\n`kick <@User> <Reason>` ~ Kicks the pinged user for the given reason" +
                "\n`removerole <@User> <Role Name>` ~ Removes the given role from the pinged user" +
                "\n`rm <# of Messages>` ~ Deletes the number of messages provided" +
                "\n`warn <@User> <Reason>` ~ Warns the pinged user for the given reason";
            string misc = "`ping` ~ Pings the bot" +
                "\n`stop` ~ Shuts the bot down" +
                "\n`uptime` ~ Shows the current uptime of the bot";
            embed.Title = "Commands for Tux";
            embed.AddField("Prefix", Bot.Config.Prefix);
            embed.AddField("General", general);
            embed.AddField("OS/Distro", osdistro);
            embed.AddField("Fun", fun);
            embed.AddField("Moderation", mod);
            embed.AddField("Misc", misc);
            embed.Color = ColorUtils.GetRandomColor();
            try
            {           
                await ctx.Member.SendMessageAsync(embed: embed).ConfigureAwait(false);
                DiscordEmbedBuilder checkEmbed = new DiscordEmbedBuilder();
                checkEmbed.Title = "Check Your DMs";
                checkEmbed.Description = "The commands have been sent to your DMs";
                checkEmbed.Color = ColorUtils.GetRandomColor();
                await ctx.Channel.TriggerTypingAsync().ConfigureAwait(false);
                await ctx.Channel.SendMessageAsync(embed: checkEmbed).ConfigureAwait(false);
            }
            catch
            {
                await ctx.Channel.TriggerTypingAsync().ConfigureAwait(false);
                await ctx.Channel.SendMessageAsync(embed: embed).ConfigureAwait(false);
            }
        }

        [Command("info")]
        public async Task Info(CommandContext ctx)
        {
            await ctx.Channel.TriggerTypingAsync().ConfigureAwait(false);
            DiscordEmbedBuilder embed = new DiscordEmbedBuilder();
            embed.WithAuthor(ctx.Guild.Name, null, ctx.Guild.IconUrl);
            embed.AddField("Bot Version", Bot.Version, true);
            embed.AddField("API", "DSharpPlus", true);
            embed.AddField("Owner", ctx.Guild.Owner.Mention, true);
            embed.AddField("Categories", ctx.Guild.GetCategories().Count.ToString(), true);
            embed.AddField("Text Channels", ctx.Guild.GetTextChannels().Count.ToString(), true);
            embed.AddField("Voice Channels", ctx.Guild.GetVoiceChannels().Count.ToString(), true);
            embed.AddField("Members", ctx.Guild.MemberCount.ToString(), true);
            embed.AddField("Humans", ctx.Guild.GetHumanCountAsync().Result.ToString(), true);
            embed.AddField("Bots", ctx.Guild.GetBotCountAsync().Result.ToString(), true);
            embed.AddField("Online", ctx.Guild.GetOnlineCountAsync().Result.ToString(), true);
            embed.AddField("Offline", ctx.Guild.GetOfflineCountAsync().Result.ToString(), true);
            embed.AddField("Roles", ctx.Guild.Roles.Count.ToString(), true);
            embed.AddField("Roles List", ctx.Guild.GetRoleList(), false);
            embed.WithFooter($"Server Created: {ctx.Guild.CreationTimestamp.DateTime.ToString("MM/dd/yyyy HH:mm:ss")}");
            embed.Color = ColorUtils.GetRandomColor();
            await ctx.Channel.SendMessageAsync(embed: embed).ConfigureAwait(false);
        }

        [Command("invite")]
        public async Task Invite(CommandContext ctx)
        {
            await ctx.Channel.TriggerTypingAsync().ConfigureAwait(false);
            DiscordEmbedBuilder embed = new DiscordEmbedBuilder();
            embed.Title = "The Tech Community";
            embed.Description = "https://discord.gg/W2V8WUF";
            embed.Color = ColorUtils.GetRandomColor();
            await ctx.Channel.SendMessageAsync(embed: embed).ConfigureAwait(false);
        }

        [Command("roleinfo")]
        public async Task RoleInfo(CommandContext ctx)
        {
            await ctx.Channel.TriggerTypingAsync().ConfigureAwait(false);
            DiscordEmbedBuilder embed = new DiscordEmbedBuilder();
            embed.Title = "Role Info";
            foreach(DiscordRole role in ctx.Guild.Roles.Values)
            {
                int memberCount = 0;
                if(role.Name == "@everyone")
                {
                    memberCount = ctx.Guild.MemberCount;
                }
                else
                {
                    foreach (DiscordMember member in ctx.Guild.Members.Values)
                    {
                        if (member.ContainsRole(role))
                        {
                            ++memberCount;
                        }
                    }
                }
                embed.AddField(role.Name, memberCount.ToString(), true);
            }
            embed.Color = ColorUtils.GetRandomColor();
            await ctx.Channel.SendMessageAsync(embed: embed).ConfigureAwait(false);
        }

        [Command("rules")]
        public async Task Rules(CommandContext ctx)
        {
            await ctx.Channel.TriggerTypingAsync().ConfigureAwait(false);
            DiscordEmbedBuilder embed = new DiscordEmbedBuilder();
            embed.Title = "The Tech Community's Rules";
            embed.AddField("Rule 1", "We welcome users of all ages, therefore please keep swearing to a minimum. Also, please keep all topics appropriate where no one would be offended by certain things.");
            embed.AddField("Rule 2", "No bashing, bullying, impersonation, etc.");
            embed.AddField("Rule 3", "No advertising of your server (unless a partner) or other products you may have to offer.");
            embed.AddField("Rule 4", "Remain peaceful and act like a normal human being, it's up to the Admin/Staff to kick/ban you if needed. As long as you are peaceful we won't bother you.");
            embed.AddField("Rule 5", "No NSFW. Please do not post anything containing NSFW content.");
            embed.AddField("Rule 6", "Don't try to scam others or promote illegal activity.");
            embed.AddField("Rule 7", "Please use the correct channel for conversations. If you have to say something that is os-specific please send it in the correct channel under the OS/Distro category. All bot commands in #bots , all memes in #memes , etc.");
            embed.Color = ColorUtils.GetRandomColor();
            await ctx.Channel.SendMessageAsync(embed: embed).ConfigureAwait(false);
        }

        [Command("source")]
        public async Task Source(CommandContext ctx)
        {
            await ctx.Channel.TriggerTypingAsync().ConfigureAwait(false);
            DiscordEmbedBuilder embed = new DiscordEmbedBuilder();
            embed.Title = "Tux's Github Repo";
            embed.Description = "https://github.com/nlogozzo/TuxBot";
            embed.Color = ColorUtils.GetRandomColor();
            await ctx.Channel.SendMessageAsync(embed: embed).ConfigureAwait(false);
        }

        [Command("suggest")]
        public async Task Suggest(CommandContext ctx, [RemainingText, Description("Your suggestion")]string suggestion)
        {
            DiscordEmbedBuilder embed = new DiscordEmbedBuilder();
            DiscordChannel suggestionChannel = ctx.Guild.GetChannelByName("suggestions");
            await suggestionChannel.TriggerTypingAsync().ConfigureAwait(false);
            embed.Title = "New Suggestion";
            embed.AddField("Suggestion", suggestion);
            embed.WithFooter(ctx.Member.Username, ctx.Member.AvatarUrl);
            embed.Color = ColorUtils.GetRandomColor();
            DiscordMessage msg = await suggestionChannel.SendMessageAsync(embed: embed).ConfigureAwait(false);
            await msg.CreateReactionAsync(DiscordEmoji.FromUnicode("👍")).ConfigureAwait(false);
            await msg.CreateReactionAsync(DiscordEmoji.FromUnicode("👎")).ConfigureAwait(false);
            await ctx.Message.DeleteAsync().ConfigureAwait(false);
        }

        [Command("verify")]
        public async Task Verify(CommandContext ctx)
        {
            await ctx.Channel.TriggerTypingAsync().ConfigureAwait(false);
            DiscordEmbedBuilder embed = new DiscordEmbedBuilder();
            DiscordRole verifiedRole = ctx.Guild.GetRoleByName("verified");
            if(ctx.Member.ContainsRole(verifiedRole))
            {
                embed.Title = "Error";
                embed.Description = $"{ctx.Member.Mention} is already verified";
                embed.Color = DiscordColor.Red;
            }
            else
            {
                await ctx.Member.GrantRoleAsync(verifiedRole).ConfigureAwait(false);
                embed.Title = "Verified!";
                embed.Description = $"{ctx.Member.Mention} is now verified";
                embed.Color = ColorUtils.GetRandomColor();
                DiscordEmbedBuilder welcomeEmbed = new DiscordEmbedBuilder();
                DiscordChannel rulesChannel = ctx.Guild.GetChannelByName("rules");
                DiscordChannel botsChannel = ctx.Guild.GetChannelByName("bots");
                welcomeEmbed.Title = "Welcome To The Tech Community";
                welcomeEmbed.AddField("Read The Rules", $"Before you begin we ask that you read the <#{rulesChannel.Id}> to ensure everyone has a good time in the community");
                welcomeEmbed.AddField("Give Yourself A Role", $"The server has custom roles for many operating systems and linux distros. Go into <#{botsChannel.Id}> and type `!help` to see the commands for the available roles");
                welcomeEmbed.AddField("OS Support", "The server also has a custom picked set of users who have experience using many different operating systems. If you ever need help, ping @OS Support for assistance");
                welcomeEmbed.AddField("Enjoy Your Stay", "Above all things, we hope you enjoy your time at The Tech Community");
                try
                {
                    await ctx.Member.SendMessageAsync(embed: welcomeEmbed).ConfigureAwait(false);
                }
                catch
                {
                    await ctx.Channel.TriggerTypingAsync().ConfigureAwait(false);
                    await ctx.Channel.SendMessageAsync(embed: welcomeEmbed).ConfigureAwait(false);
                }
            }
            await ctx.Channel.SendMessageAsync(embed: embed).ConfigureAwait(false);
        }

        [Command("whois")]
        public async Task Whois(CommandContext ctx, [Description("User to view info on")]DiscordMember user = null)
        {
            await ctx.Channel.TriggerTypingAsync().ConfigureAwait(false);
            DiscordEmbedBuilder embed = new DiscordEmbedBuilder();
            if(user == null)
            {
                user = ctx.Member;
            }
            DiscordRole verifiedRole = ctx.Guild.GetRoleByName("verified");
            embed.WithAuthor(user.Username, null, user.AvatarUrl);
            embed.AddField("User Tag", user.Mention, true);
            embed.AddField("Real Name", user.Username, true);
            try
            {
                embed.AddField("Nickname", user.Nickname, true);
            }
            catch
            {
                embed.AddField("Nickname", "N/A", true);
            }
            if(user.Presence == null)
            {
                embed.AddField("Status", "Offline", true);
            }
            else
            {
                embed.AddField("Status", user.Presence.Status.ToString(), true);
            }
            embed.AddField("Joined", user.JoinedAt.DateTime.ToString(), true);
            embed.AddField("Is Bot", user.IsBot.ToString(), true);
            embed.AddField("Is Verified", user.ContainsRole(verifiedRole).ToString(), true);
            embed.AddField("Role List", user.GetRoleList());
            embed.ThumbnailUrl = user.AvatarUrl;
            embed.Color = ColorUtils.GetRandomColor();
            await ctx.Channel.SendMessageAsync(embed: embed).ConfigureAwait(false);
        }
    }
}
