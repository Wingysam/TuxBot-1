using System.Collections.Generic;
using DSharpPlus.Entities;

namespace TuxBot.Utils
{
    public static class RoleUtils
    {
        public static DiscordRole GetRoleByName(this DiscordGuild guild, string roleName, bool ignoreCase = true)
        {
            foreach (DiscordRole role in guild.Roles)
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
            List<DiscordRole> roles = new List<DiscordRole>();
            string roleList = "";
            foreach(DiscordRole role in member.Roles)
            {
                roles.Add(role);
            }
            for (int i = 0; i < roles.Count; i++)
            {
                roleList += roles[i].Name;
                if (i != roles.Count - 1)
                {
                    roleList += ", ";
                }
            }
            return roleList;
        }

        public static string GetRoleList(this DiscordGuild guild)
        {
            string roleList = "";
            for (int i = 0; i < guild.Roles.Count; i++)
            {
                roleList += guild.Roles[i].Name;
                if (i != guild.Roles.Count - 1)
                {
                    roleList += ", ";
                }
            }
            return roleList;
        }
    }
}
