using System;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.EventArgs;
using DSharpPlus.CommandsNext;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using DiscordBot.Commands;

namespace DiscordBot
{
    public class Bot
    {
        public CommandsNextModule Commands{get;private set;}

        public DiscordClient Client { get; private set; }


        public async Task RunAsync()
        {
            //Loading config file
            var json = string.Empty;


              using(var fs =  File.OpenRead("Config.json")){
                  using(var sr = new StreamReader(fs,new UTF8Encoding(false))){
                     json = await sr.ReadToEndAsync().ConfigureAwait(false);
                  }
              }

            var configJson =  JsonConvert.DeserializeObject<ConfigJson>(json);

            //Bot Config Setting
            var config = new DiscordConfiguration 
            {
                Token = configJson.Token,
                TokenType = TokenType.Bot,
                AutoReconnect = true,
                LogLevel = LogLevel.Debug,
                UseInternalLogHandler = true

             };

            Client = new DiscordClient(config);

            //Event
            Client.Ready += OnClientReady;


            //Bot Command Setting
            var commandsConfig = new CommandsNextConfiguration
            {
                StringPrefix = configJson.Prefix,
                EnableDms = true,
                EnableMentionPrefix = true,
            };

            Commands = Client.UseCommandsNext(commandsConfig);

            Commands.RegisterCommands<FunCommands>();

            await Client.ConnectAsync();

            await Task.Delay(-1);
        }


        private Task OnClientReady(ReadyEventArgs e){
            return Task.CompletedTask;
        }
    }
}
