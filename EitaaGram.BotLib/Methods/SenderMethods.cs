using EitaaGram.BotLib.BotClient;
using EitaaGram.BotLib.Helpers;
using EitaaGram.BotLib.Types;
using EitaaGram.BotLib.Network;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http;

namespace EitaaGram.BotLib.Methods
{
    public static class SenderMethods
    {
        /// <summary>
        /// با این متد میتوانید اطلاعات اکانت خود را دریافت کنید
        /// </summary>
        /// <returns>یک نمونه از یوزرتایپ دریافت میکنید</returns>
        /// 
        public static async Task<UserType> GetMeAsync(this EitaaGramBotClient client)
        {
            return await Task.Run(async () =>
               {
                   var sender = new RequestSender(BotInformation.GetAPIURL("getMe"));
                   await sender.MakeRequest();
                   return sender.ConvertStringToObject<UserType>();
               });
        }


        /// <summary>
        /// با این متد میتوانید پیام ارسال کنید در صورت موفقیت آمیز بودن عملیات یک نمونه از مسیج تایپ دریافت میکنید در غیر این صورت خطا دریافت میکنید
        /// </summary>
        /// <param name="chatId">شناسه منحصر به فرد کانال یا گروه که در قسمت کانال ها در پنل ایتاریار برای هرکانال موجود است ، البته میتوانید به جای شناسه از یوزرنیم کانال بدون @ استفاده کنید (اجباری) است</param>
        /// <param name="text">متن پیامی که میخواهید ارسال کنید (اجباری) است</param>
        /// <param name="title">عنوان مطلب که فقط در پنل کاربرد دارد و برای جساجو و نمایش لیسای پیغام اساداد میشود (اختیاری) است</param>
        /// <param name="disable_notification">اگر با عدد یک مقدار دهی شود، پیام را بدون نوتیفیکشن برای کاربر ارسال میکند (اختیاری) است</param>
        /// <param name="reply_to_message_id">اگر میخواهید متنی که ارسال میکنید در جواب یک پیغام دیگر باشد ، شناسه ی آن مطلب در پیام رسان ایتا را با استفاده از این پارامتر مشخص کنید (اختیاری) است</param>
        /// <param name="date">تاریخ و زمان ارسال پیغام که برای ارسال زمان بندی (اختیاری) است</param>
        /// <param name="pin">گر با مقدار 1 مقدار دهی شود، پیغام بعد از ارسال، در کانال یا گرو سنجاق میشود (اختیاری) است</param>
        /// <param name="viewCountForDelete">وقتی که تعداد مشاهد ی پیام توسط کاربران ایتا به این عدد برسد، پیغام فوق حذف میشود (اختیاری) است</param>
        /// <returns></returns>
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


        /// <summary>
        /// با این متد میتوانید فایل ارسال کنید
        /// </summary>
        /// <param name="chatId">شناسه منحصر به فرد کانال یا گروه که در قسمت کانال ها در پنل ایتاریار برای هرکانال موجود است ، البته میتوانید به جای شناسه از یوزرنیم کانال بدون @ استفاده کنید (اجباری) است</param>
        /// <param name="caption">کپشن یا همان توضیخات فایل که در زیر فایل قرار میگیرد (اختیاری) است</param>
        /// <param name="title">عنوان مطلب که فقط در پنل کاربرد دارد و برای جساجو و نمایش لیسای پیغام اساداد میشود (اختیاری) است</param>
        /// <param name="disable_notification">اگر با عدد یک مقدار دهی شود، پیام را بدون نوتیفیکشن برای کاربر ارسال میکند (اختیاری) است</param>
        /// <param name="reply_to_message_id">اگر میخواهید متنی که ارسال میکنید در جواب یک پیغام دیگر باشد ، شناسه ی آن مطلب در پیام رسان ایتا را با استفاده از این پارامتر مشخص کنید (اختیاری) است</param>
        /// <param name="date">تاریخ و زمان ارسال پیغام که برای ارسال زمان بندی (اختیاری) است</param>
        /// <param name="pin">گر با مقدار 1 مقدار دهی شود، پیغام بعد از ارسال، در کانال یا گرو سنجاق میشود (اختیاری) است</param>
        /// <param name="viewCountForDelete">وقتی که تعداد مشاهد ی پیام توسط کاربران ایتا به این عدد برسد، پیغام فوق حذف میشود (اختیاری) است</param>
        public static async Task<FileType> SendFileAsync(this EitaaGramBotClient client,
            string chatId, string filePath, string caption = null, string title = null, bool disable_notification = false, long reply_to_message_id = 0, TimeSpan date = default, bool pin = false, long viewCountForDelete = 0)
        {
            return await Task.Run(async () =>
            {
                if (!File.Exists(filePath))
                    throw new FileNotFoundException(filePath);

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
