using EitaaGram.BotLib.Methods;
using System;
using System.Collections.Generic;
using System.Text;

namespace EitaaGram.BotLib.BotClient
{
    public class EitaaGramBotClient
    {
        private string Token => BotInformation.GetToken();

        /// <summary>
        /// ساخت ربات
        /// </summary>
        /// <param name="Token">توکن فایل خود که از ایتا یار دریافت کردید قرار دهید</param>
        public EitaaGramBotClient(string Token)
        {
            BotInformation.SetToken(Token);
        }
    }
}
