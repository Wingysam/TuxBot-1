using System.Collections.Generic;
using DSharpPlus;
using DSharpPlus.Entities;

namespace TuxBot.Utils
{
    public static class ChannelUtils
    {
        public static DiscordChannel GetChannelByName(this DiscordGuild guild, string channelName, bool ignoreCase = true)
        {
            foreach (DiscordChannel channel in guild.Channels)
            {
                if (ignoreCase)
                {
                    if (channel.Name.ToLower() == channelName.ToLower())
                    {
                        return channel;
                    }
                }
                else
                {
                    if (channel.Name == channelName)
                    {
                        return channel;
                    }
                }
            }
            return null;
        }

        public static IReadOnlyList<DiscordChannel> GetCategories(this DiscordGuild guild)
        {
            List<DiscordChannel> categories = new List<DiscordChannel>();
            foreach (DiscordChannel channel in guild.Channels)
            {
                if (channel.Type == ChannelType.Category)
                {
                    categories.Add(channel);
                }
            }
            return categories;
        }

        public static IReadOnlyList<DiscordChannel> GetTextChannels(this DiscordGuild guild)
        {
            List<DiscordChannel> textChannels = new List<DiscordChannel>();
            foreach (DiscordChannel channel in guild.Channels)
            {
                if(channel.Type == ChannelType.Text)
                {
                    textChannels.Add(channel);
                }
            }
            return textChannels;
        }

        public static IReadOnlyList<DiscordChannel> GetVoiceChannels(this DiscordGuild guild)
        {
            List<DiscordChannel> voiceChannels = new List<DiscordChannel>();
            foreach (DiscordChannel channel in guild.Channels)
            {
                if (channel.Type == ChannelType.Voice)
                {
                    voiceChannels.Add(channel);
                }
            }
            return voiceChannels;
        }

    }
}
