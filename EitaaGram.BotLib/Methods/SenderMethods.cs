using EitaaGram.BotLib.BotClient;
using EitaaGram.BotLib.Exceptions;
using EitaaGram.BotLib.Helpers;
using EitaaGram.BotLib.Models;
using EitaaGram.BotLib.Network;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EitaaGram.BotLib.Methods
{
    public static class SenderMethods
    {
        public static async Task<UserModel> GetMeAsync(this EitaaGramBotClient client)
        {
            return await Task.Run(async () =>
               {
                   var sender = new RequestSender(BotInformation.GetAPIURL("getMe"));
                   await sender.MakeRequest();
                   return sender.ConvertStringToObject<UserModel>().result;
               });
        }


        public static async Task<SendedResultModel> SendMessageAsync(this EitaaGramBotClient client,
            string chatId, string text, string title = null, bool disable_notification = false, long reply_to_message_id = 0, TimeSpan date = default, bool pin = false, long viewCountForDelete = 0)
        {
            return await Task.Run(async () =>
            {
                var json = new JObject {
                { "chat_id", chatId },
                { "text", text },
                {"disable_notification",disable_notification },
                { "pin",pin}
            };

                if (title != null)
                    json.Add("title", title);
                if (reply_to_message_id != 0)
                    json.Add("reply_to_message_id", reply_to_message_id);
                if (date != default)
                    json.Add("date", date);
                if (viewCountForDelete != 0)
                    json.Add("viewCountForDelete", viewCountForDelete);

                var sender = new RequestSender(BotInformation.GetAPIURL("SendMessage"));
                sender.AddBody(json.ToString());
                await sender.MakeRequest();

                return sender.ConvertStringToObject<SendedResultModel>().result;
            });

        }


    }
}
