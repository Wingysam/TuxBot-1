using System;
using DSharpPlus.Entities;

namespace TuxBot.Utils
{
    public static class ColorUtils
    {
        public static DiscordColor GetRandomColor()
        {
            int rNum = new Random().Next(1, 21);
            switch(rNum)
            {
                case 1:
                    return DiscordColor.Red;
                case 2:
                    return DiscordColor.Orange;
                case 3:
                    return DiscordColor.Yellow;
                case 4:
                    return DiscordColor.Green;
                case 5:
                    return DiscordColor.Blue;
                case 6:
                    return DiscordColor.Purple;
                case 7:
                    return DiscordColor.HotPink;
                case 8:
                    return DiscordColor.Gray;
                case 9:
                    return DiscordColor.Black;
                case 10:
                    return DiscordColor.Brown;
                case 11:
                    return DiscordColor.White;
                case 12:
                    return DiscordColor.Gold;
                case 13:
                    return DiscordColor.Teal;
                case 14:
                    return DiscordColor.Violet;
                case 15:
                    return DiscordColor.Azure;
                case 16:
                    return DiscordColor.Magenta;
                case 17:
                    return DiscordColor.Grayple;
                case 18:
                    return DiscordColor.Blurple;
                case 19:
                    return DiscordColor.None;
                case 20:
                    return DiscordColor.Rose;
                default:
                    return DiscordColor.Black;
            }
        }
    }
}
