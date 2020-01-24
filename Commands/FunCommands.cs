using System;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Threading.Tasks;

namespace DiscordBot.Commands
{
    
    public class FunCommands
    {
        [Command("ping")]
        public async Task Ping(CommandContext ctx)
        {
           await ctx.Channel.SendMessageAsync("Pong ").ConfigureAwait(false);
        }

        [Command("cal")]
        [Description("計算機")]
        public async Task Speak(CommandContext ctx,[Description("數字(1)")]int x, [Description("符號")] string symbol, [Description("數字(2)")]int y)
        {
            Console.WriteLine($"Discord Bot Recieve");

            float _value = 0;

            switch (symbol)
            {
                case "+":
                    _value = x + y;
                    break;
                case "-":
                    _value = x - y;
                    break;
                case "*":
                    _value = x * y;
                    break;
                case "/":
                    _value = x / y;
                    break;

                default:
                    break;
            }


            await ctx.Channel.SendMessageAsync($"{_value}").ConfigureAwait(false);
        }

        DivinationData divinationData = new DivinationData();

        [Command("垃圾占卜")]
        public async Task GarbageDivination(CommandContext ctx,string name)
        {
            string animal = "";
            string adj = "";


            animal = divinationData.RandomAnimal();
            adj = divinationData.RandomAdj();

            await ctx.Channel.SendMessageAsync($"{name}是一隻{adj}{animal}").ConfigureAwait(false);
        }
    }

    
}
