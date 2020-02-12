using System.Threading.Tasks;
using DSharpPlus.Entities;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using TuxBot.Utils;

namespace TuxBot.Commands
{
    public enum OS
    {
        Android,
        Arch,
        Bsd,
        CentOS,
        Debian,
        Fedora,
        Gentoo,
        MacOS,
        Manjaro,
        Other,
        RedHat,
        Suse,
        Ubuntu,
        Windows
    };

    public class OSDistro : BaseCommandModule
    {
        private async Task GetOSRole(CommandContext ctx, OS os)
        {
            await ctx.Channel.TriggerTypingAsync().ConfigureAwait(false);
            DiscordEmbedBuilder embed = new DiscordEmbedBuilder();
            DiscordRole osRole;
            switch(os)
            {
                case OS.Android:
                    osRole = ctx.Guild.GetRoleByName("android");
                    break;
                case OS.Arch:
                    osRole = ctx.Guild.GetRoleByName("arch");
                    break;
                case OS.Bsd:
                    osRole = ctx.Guild.GetRoleByName("bsd");
                    break;
                case OS.CentOS:
                    osRole = ctx.Guild.GetRoleByName("centos");
                    break;
                case OS.Debian:
                    osRole = ctx.Guild.GetRoleByName("debian");
                    break;
                case OS.Fedora:
                    osRole = ctx.Guild.GetRoleByName("fedora");
                    break;
                case OS.Gentoo:
                    osRole = ctx.Guild.GetRoleByName("gentoo");
                    break;
                case OS.MacOS:
                    osRole = ctx.Guild.GetRoleByName("macos");
                    break;
                case OS.Manjaro:
                    osRole = ctx.Guild.GetRoleByName("manjaro");
                    break;
                case OS.Other:
                    osRole = ctx.Guild.GetRoleByName("other");
                    break;
                case OS.RedHat:
                    osRole = ctx.Guild.GetRoleByName("redhat");
                    break;
                case OS.Suse:
                    osRole = ctx.Guild.GetRoleByName("suse");
                    break;
                case OS.Ubuntu:
                    osRole = ctx.Guild.GetRoleByName("ubuntu");
                    break;
                case OS.Windows:
                    osRole = ctx.Guild.GetRoleByName("windows");
                    break;
                default:
                    osRole = ctx.Guild.GetRoleByName("other");
                    break;
            }
            if (ctx.Member.ContainsRole(osRole))
            {
                embed.Title = "Distro Role Removed";
                embed.AddField("User", ctx.Member.Mention);
                embed.AddField("Role", osRole.Mention);
                embed.Color = ColorUtils.GetRandomColor();
                await ctx.Member.RevokeRoleAsync(osRole).ConfigureAwait(false);
            }
            else
            {
                embed.Title = "Distro Role Added";
                embed.AddField("User", ctx.Member.Mention);
                embed.AddField("Role", osRole.Mention);
                embed.Color = ColorUtils.GetRandomColor();
                await ctx.Member.GrantRoleAsync(osRole).ConfigureAwait(false);
            }
            await ctx.Channel.SendMessageAsync(embed: embed).ConfigureAwait(false);
        }

        [Command("android")]
        public async Task Android(CommandContext ctx)
        {
            await GetOSRole(ctx, OS.Android);
        }

        [Command("arch")]
        public async Task Arch(CommandContext ctx)
        {
            await GetOSRole(ctx, OS.Arch);
        }

        [Command("bsd")]
        public async Task Bsd(CommandContext ctx)
        {
            await GetOSRole(ctx, OS.Bsd);
        }

        [Command("centos")]
        public async Task CentOS(CommandContext ctx)
        {
            await GetOSRole(ctx, OS.CentOS);
        }

        [Command("debian")]
        public async Task Debian(CommandContext ctx)
        {
            await GetOSRole(ctx, OS.Debian);
        }

        [Command("fedora")]
        public async Task Fedora(CommandContext ctx)
        {
            await GetOSRole(ctx, OS.Fedora);
        }

        [Command("gentoo")]
        public async Task Gentoo(CommandContext ctx)
        {
            await GetOSRole(ctx, OS.Gentoo);
        }

        [Command("macos")]
        public async Task MacOS(CommandContext ctx)
        {
            await GetOSRole(ctx, OS.MacOS);
        }

        [Command("Manjaro")]
        public async Task Manjaro(CommandContext ctx)
        {
            await GetOSRole(ctx, OS.Manjaro);
        }

        [Command("other")]
        public async Task Other(CommandContext ctx)
        {
            await GetOSRole(ctx, OS.Other);
        }

        [Command("redhat")]
        public async Task RedHat(CommandContext ctx)
        {
            await GetOSRole(ctx, OS.RedHat);
        }

        [Command("suse")]
        public async Task Suse(CommandContext ctx)
        {
            await GetOSRole(ctx, OS.Suse);
        }

        [Command("ubuntu")]
        public async Task Ubuntu(CommandContext ctx)
        {
            await GetOSRole(ctx, OS.Ubuntu);
        }

        [Command("windows")]
        public async Task Windows(CommandContext ctx)
        {
            await GetOSRole(ctx, OS.Windows);
        }
    }
}
