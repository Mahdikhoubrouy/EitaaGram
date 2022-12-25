using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EitaaGram.BotLib.Models
{
    public class SendedResultModel
    {
        public string message_id { get; set; }
        public UserModel from { get; set; }
        public ChatModel chat { get; set; }
        public string date { get; set; }
        public string text { get; set; }
    }
}
