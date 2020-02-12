using System;
using DSharpPlus.Entities;

namespace TuxBot.Utils
{
    public static class ActivityUtils
    {
        public static DiscordActivity GetRandomActivity()
        {
            int rNum = new Random().Next(1, 6);
            switch (rNum)
            {
                case 1:
                    return new DiscordActivity("Linus", ActivityType.ListeningTo);
                case 2:
                    return new DiscordActivity("Bash Terminal", ActivityType.Playing);
                case 3:
                    return new DiscordActivity("ZSH Terminal", ActivityType.Playing);
                case 4:
                    return new DiscordActivity("Super Tux Kart", ActivityType.Playing);
                case 5:
                    return new DiscordActivity("The Mysteries of Unix", ActivityType.Watching);
                default:
                    return new DiscordActivity("Linus", ActivityType.ListeningTo);
            }
        }
    }
}
