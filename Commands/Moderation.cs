using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using DSharpPlus;
using DSharpPlus.Net.Models;
using DSharpPlus.Entities;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using TuxBot.Utils;

namespace TuxBot.Commands
{
    public class Moderation : BaseCommandModule
    {
        [Command("addrole")]
        [RequirePermissions(Permissions.ManageRoles)]
        public async Task AddRole(CommandContext ctx, [Description("User to add role to")]DiscordMember user, [Description("Role name")]string roleName)
        {
            await ctx.Channel.TriggerTypingAsync().ConfigureAwait(false);
            DiscordEmbedBuilder embed = new DiscordEmbedBuilder();
            DiscordRole role = ctx.Guild.GetRoleByName(roleName);
            if (role == null)
            {
                embed.Title = "Error";
                embed.AddField("Invalid Role", "That role does not exists in this server");
                embed.Color = DiscordColor.Red;
            }
            else
            {
                if(!ctx.Member.IsOwner && (role == ctx.Guild.GetRoleByName("admin") || role == ctx.Guild.GetRoleByName("staff")))
                {
                    embed.Title = "Error";
                    embed.AddField("Invalid Permissions", "Only the server admin can add the admin/staff roles");
                    embed.Color = DiscordColor.Red;
                }
                else if (user.ContainsRole(role))
                {
                    embed.Title = "Error";
                    embed.AddField("User Contains Role", $"{user.Mention} already contains the role {role.Mention}");
                    embed.Color = DiscordColor.Red;
                }
                else
                {
                    await ctx.Member.GrantRoleAsync(role).ConfigureAwait(false);
                    embed.Title = "Role Added To User";
                    embed.AddField("User", user.Mention);
                    embed.AddField("Role", role.Mention);
                    embed.Color = ColorUtils.GetRandomColor();
                }
            }
            await ctx.Channel.SendMessageAsync(embed: embed).ConfigureAwait(false);
            DiscordChannel logChannel = ctx.Guild.GetChannelByName("tux-logs");
            embed.AddField("Ran By", ctx.Member.Mention);
            await logChannel.SendMessageAsync(embed: embed).ConfigureAwait(false);
        }

        [Command("ban")]
        [RequirePermissions(Permissions.BanMembers)]
        public async Task Ban(CommandContext ctx, [Description("User to ban")]DiscordMember user, [RemainingText, Description("Reason for ban")]string reason)
        {
            await ctx.Channel.TriggerTypingAsync().ConfigureAwait(false);
            DiscordEmbedBuilder embed = new DiscordEmbedBuilder();
            if (user == ctx.Guild.Owner)
            {
                embed.Title = "Error";
                embed.AddField("Invalid User", "You can't ban the owner");
                embed.Color = DiscordColor.Red;
            }
            else
            {
                await ctx.Guild.BanMemberAsync(user, 7, reason).ConfigureAwait(false);
                embed.Title = "User Banned";
                embed.AddField("User", user.Mention);
                embed.AddField("Reason", reason);
                embed.Color = ColorUtils.GetRandomColor();
                await ctx.Message.DeleteAsync().ConfigureAwait(false);
            }
            await ctx.Channel.SendMessageAsync(embed: embed).ConfigureAwait(false);
            DiscordChannel logChannel = ctx.Guild.GetChannelByName("tux-logs");
            embed.AddField("Ran By", ctx.Member.Mention);
            await logChannel.SendMessageAsync(embed: embed).ConfigureAwait(false);
        }

        [Command("kick")]
        [RequirePermissions(Permissions.KickMembers)]
        public async Task Kick(CommandContext ctx, [Description("User to kick")]DiscordMember user, [RemainingText, Description("Reason for kick")]string reason)
        {
            await ctx.Channel.TriggerTypingAsync().ConfigureAwait(false);
            DiscordEmbedBuilder embed = new DiscordEmbedBuilder();
            if (user == ctx.Guild.Owner)
            {
                embed.Title = "Error";
                embed.AddField("Invalid User", "You can't kick the owner");
                embed.Color = DiscordColor.Red;
            }
            else
            {
                await ctx.Member.RemoveAsync(reason).ConfigureAwait(false);
                embed.Title = "User Kicked";
                embed.AddField("User", user.Mention);
                embed.AddField("Reason", reason);
                embed.Color = ColorUtils.GetRandomColor();
                await ctx.Message.DeleteAsync().ConfigureAwait(false);
            }
            await ctx.Channel.SendMessageAsync(embed: embed).ConfigureAwait(false);
            DiscordChannel logChannel = ctx.Guild.GetChannelByName("tux-logs");
            embed.AddField("Ran By", ctx.Member.Mention);
            await logChannel.SendMessageAsync(embed: embed).ConfigureAwait(false);
        }

        [Command("removerole")]
        [RequirePermissions(Permissions.ManageRoles)]
        public async Task RemoveRole(CommandContext ctx, [Description("User to remove role from")]DiscordMember user, [Description("Role name")]string roleName)
        {
            await ctx.Channel.TriggerTypingAsync().ConfigureAwait(false);
            DiscordEmbedBuilder embed = new DiscordEmbedBuilder();
            DiscordRole role = ctx.Guild.GetRoleByName(roleName);
            if (role == null)
            {
                embed.Title = "Error";
                embed.AddField("Invalid Role", "That role does not exists in this server");
                embed.Color = DiscordColor.Red;
            }
            else
            {
                if (!ctx.Member.IsOwner && (role == ctx.Guild.GetRoleByName("admin") || role == ctx.Guild.GetRoleByName("staff")))
                {
                    embed.Title = "Error";
                    embed.AddField("Invalid Permissions", "Only the server admin can remove the admin/staff roles");
                    embed.Color = DiscordColor.Red;
                }
                else if (user.ContainsRole(role))
                {
                    await ctx.Member.RevokeRoleAsync(role).ConfigureAwait(false);
                    embed.Title = "Role Removed From User";
                    embed.AddField("User", user.Mention);
                    embed.AddField("Role", role.Mention);
                    embed.Color = ColorUtils.GetRandomColor();
                }
                else
                {
                    embed.Title = "Error";
                    embed.AddField("User Doesn't Contain Role", $"{user.Mention} doesn't contain the role {role.Mention}");
                    embed.Color = DiscordColor.Red;
                }
            }
            await ctx.Channel.SendMessageAsync(embed: embed).ConfigureAwait(false);
            DiscordChannel logChannel = ctx.Guild.GetChannelByName("tux-logs");
            embed.AddField("Ran By", ctx.Member.Mention);
            await logChannel.SendMessageAsync(embed: embed).ConfigureAwait(false);
        }

        [Command("rm")]
        [RequirePermissions(Permissions.ManageMessages)]
        public async Task Rm(CommandContext ctx, [Description("Number of messages to delete")]int numberOfMessages)
        {
            await ctx.Channel.TriggerTypingAsync().ConfigureAwait(false);
            DiscordEmbedBuilder embed = new DiscordEmbedBuilder();
            if (numberOfMessages < 2 || numberOfMessages > 100)
            {
                embed.Title = "Error";
                embed.AddField("Invalid Number of Messages", "Please provide a number between 2-100");
                embed.Color = DiscordColor.Red;
            }
            else
            {
                await ctx.Message.DeleteAsync().ConfigureAwait(false);
                IReadOnlyList<DiscordMessage> messages = await ctx.Channel.GetMessagesAsync(numberOfMessages).ConfigureAwait(false);
                await ctx.Channel.DeleteMessagesAsync(messages).ConfigureAwait(false);
                embed.Title = "Messages Deleted";
                embed.AddField("Number of Messages Deleted", numberOfMessages.ToString());
                embed.Color = ColorUtils.GetRandomColor();
            }
            await ctx.Channel.SendMessageAsync(embed: embed).ConfigureAwait(false);
            DiscordChannel logChannel = ctx.Guild.GetChannelByName("tux-logs");
            embed.AddField("Channel", ctx.Channel.Mention);
            embed.AddField("Ran By", ctx.Member.Mention);
            await logChannel.SendMessageAsync(embed: embed).ConfigureAwait(false);
        }

        [Command("warn")]
        [RequirePermissions(Permissions.KickMembers)]
        public async Task Warn(CommandContext ctx, [Description("User to warn")]DiscordMember user, [RemainingText, Description("Reason for warning")]string reason)
        {
            await ctx.Channel.TriggerTypingAsync().ConfigureAwait(false);
            DiscordEmbedBuilder embed = new DiscordEmbedBuilder();
            if (user == ctx.Guild.Owner)
            {
                embed.Title = "Error";
                embed.AddField("Invalid User", "You can't warn to owner");
                embed.Color = DiscordColor.Red;
            }
            else
            {
                embed.Title = "New Warning";
                embed.AddField("User", user.Mention);
                embed.AddField("Reason", reason);
                embed.Color = ColorUtils.GetRandomColor();
                await ctx.Message.DeleteAsync().ConfigureAwait(false);
            }
            await ctx.Channel.SendMessageAsync(embed: embed).ConfigureAwait(false);
            DiscordChannel logChannel = ctx.Guild.GetChannelByName("tux-logs");
            embed.AddField("Ran By", ctx.Member.Mention);
            await logChannel.SendMessageAsync(embed: embed).ConfigureAwait(false);
        }
    }
}
