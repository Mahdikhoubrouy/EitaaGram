using System;
using System.Collections.Generic;
using System.Text;

namespace EitaaGram.BotLib.BotClient
{
    public class EitaaGramBotClient
    {
        private string Token => BotInformation.GetToken();

        public EitaaGramBotClient(string Token)
        {
            BotInformation.SetToken(Token);
        }


    }
}
