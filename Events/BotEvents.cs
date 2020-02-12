using System;
using System.Threading.Tasks;
using DSharpPlus.EventArgs;
using TuxBot.Utils;

namespace TuxBot.Events
{
    public static class BotEvents
    {
        public async static Task Ready(ReadyEventArgs args)
        {
            Console.WriteLine("[BOT] Ready");
            await args.Client.UpdateStatusAsync(activity: ActivityUtils.GetRandomActivity());
        }
    }
}
