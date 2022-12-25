using System;
using System.Collections.Generic;
using System.Text;

namespace EitaaGram.BotLib.BotClient
{
    public class EitaaGramBotClient
    {
        public EitaaGramBotClient(string Token)
        {
            BotInformation.SetToken(Token);
        }


    }
}
