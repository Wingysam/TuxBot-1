using System;
using System.Threading.Tasks;
using DSharpPlus.EventArgs;

namespace TuxBot.Events
{
    public static class BotEvents
    {
        public static Task Ready(ReadyEventArgs args)
        {
            Console.WriteLine("[BOT] Ready");
            return Task.CompletedTask;
        }
    }
}
