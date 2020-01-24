using System;

namespace DiscordBot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Discord Bot Start");

            var bot = new Bot();
            bot.RunAsync().GetAwaiter().GetResult();
            
        }
    }
}
