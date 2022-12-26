namespace EitaaGram.Bot.BotClient
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
