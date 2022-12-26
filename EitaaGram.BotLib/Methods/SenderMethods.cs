using EitaaGram.BotLib.BotClient;
using EitaaGram.BotLib.Exceptions;
using EitaaGram.BotLib.Helpers;
using EitaaGram.BotLib.Types;
using EitaaGram.BotLib.Network;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.IO;
using System.Net.Http;
using System.Net.NetworkInformation;

namespace EitaaGram.BotLib.Methods
{
    public static class SenderMethods
    {

        public static async Task<UserType> GetMeAsync(this EitaaGramBotClient client)
        {
            return await Task.Run(async () =>
               {
                   var sender = new RequestSender(BotInformation.GetAPIURL("getMe"));
                   await sender.MakeRequest();
                   return sender.ConvertStringToObject<UserType>();
               });
        }


        public static async Task<MessageType> SendMessageAsync(this EitaaGramBotClient client,
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

                return sender.ConvertStringToObject<MessageType>();
            });

        }

        public static async Task<FileType> SendFileAsync(this EitaaGramBotClient client,
            string chatId, string filePath, string caption = null, string title = null, bool disable_notification = false, long reply_to_message_id = 0, TimeSpan date = default, bool pin = false, long viewCountForDelete = 0)
        {
            return await Task.Run(async () =>
            {
                var contents = new Dictionary<string, StringContent>()
                {
                    {"chat_id",new StringContent(chatId) },
                    {"disable_notification",new StringContent(disable_notification.ToString()) },
                    {"pin",new StringContent(pin.ToString()) }
                };

                if (title != null)
                    contents.Add("title", new StringContent(title));
                if (caption != null)
                    contents.Add("caption", new StringContent(caption));
                if (reply_to_message_id != 0)
                    contents.Add("reply_to_message_id", new StringContent(reply_to_message_id.ToString()));
                if (date != default)
                    contents.Add("date", new StringContent(date.ToString()));
                if (viewCountForDelete != 0)
                    contents.Add("viewCountForDelete", new StringContent(viewCountForDelete.ToString()));

                var sender = new RequestSender(BotInformation.GetAPIURL("sendfile"));
                sender.AddFile(contents, filePath, "test");
                await sender.MakeRequest();

                return sender.ConvertStringToObject<FileType>();
            });
        }
    }
}
