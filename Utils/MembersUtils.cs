using System.Threading.Tasks;
using DSharpPlus.Entities;

namespace TuxBot.Utils
{
    public static class MembersUtils
    {

        public static async Task<int> GetOnlineCountAsync(this DiscordGuild guild)
        {
            int onlineCount = 0;
            foreach(DiscordMember member in await guild.GetAllMembersAsync().ConfigureAwait(false))
            {
                if(member.Presence != null)
                {
                    if (member.Presence.Status == UserStatus.Online || member.Presence.Status == UserStatus.Idle || member.Presence.Status == UserStatus.DoNotDisturb)
                    {
                        onlineCount++;
                    }
                }
                
            }
            return onlineCount;
        }

        public static async Task<int> GetOfflineCountAsync(this DiscordGuild guild)
        {
            int offlineCount = 0;
            foreach (DiscordMember member in await guild.GetAllMembersAsync().ConfigureAwait(false))
            {
                if (member.Presence == null || member.Presence.Status == UserStatus.Invisible)
                {
                    offlineCount++;
                }
            }
            return offlineCount;
        }

        public static async Task<int> GetHumanCountAsync(this DiscordGuild guild)
        {
            int humanCount = 0;
            foreach (DiscordMember member in await guild.GetAllMembersAsync().ConfigureAwait(false))
            {
                if(!member.IsBot)
                {
                    humanCount++;
                }
            }
            return humanCount;
        }

        public static async Task<int> GetBotCountAsync(this DiscordGuild guild)
        {
            int botCount = 0;
            foreach (DiscordMember member in await guild.GetAllMembersAsync().ConfigureAwait(false))
            {
                if(member.IsBot)
                {
                    botCount++;
                }
            }
            return botCount;
        }
    }
}
