using System;
using System.Collections.Generic;
using System.Text;

namespace EitaaGram.BotLib.BotClient
{
    internal static class BotInformation
    {
        private static string Token;

        public static void SetToken(string token)
        {
            Token = token;
        }

        public static string GetToken()
        {
            return Token;
        }

        public static string GetAPIURL(string Token, string Method)
        {
            return $"https://eitaayar.ir/api/{Token}/{Method}";
        }

    }
}
