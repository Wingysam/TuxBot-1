using System.Linq;
using DSharpPlus.Entities;

namespace TuxBot.Utils
{
    public static class RoleUtils
    {
        public static DiscordRole GetRoleByName(this DiscordGuild guild, string roleName, bool ignoreCase = true)
        {
            foreach (DiscordRole role in guild.Roles.Values)
            {
                if(ignoreCase)
                {
                    if(role.Name.ToLower() == roleName.ToLower())
                    {
                        return role;
                    }
                }
                else
                {
                    if(role.Name == roleName)
                    {
                        return role;
                    }
                }
            }
            return null;
        }

        public static bool ContainsRole(this DiscordMember member, DiscordRole role)
        {
            foreach(DiscordRole r in member.Roles)
            {
                if(r == role)
                {
                    return true;
                }
            }
            return false;
        }

        public static string GetRoleList(this DiscordMember member)
        {
            string roleList = "";
            int i = 0;
            foreach(DiscordRole role in member.Roles)
            {
                roleList += role.Name;
                if (i != member.Roles.Count() - 1)
                {
                    roleList += ", ";
                }
                i++;
            }
            return roleList;
        }

        public static string GetRoleList(this DiscordGuild guild)
        {
            string roleList = "";
            int i = 0;
            foreach (DiscordRole role in guild.Roles.Values)
            {
                roleList += role.Name;
                if (i != guild.Roles.Count - 1)
                {
                    roleList += ", ";
                }
                i++;
            }
            return roleList;
        }
    }
}
