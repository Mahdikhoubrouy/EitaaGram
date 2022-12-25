using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EitaaGram.BotLib.Models
{
    public class SendedResultModel
    {
        public string MessageId { get; set; }
        public UserModel From { get; set; }
        public ChatModel Chat { get; set; }
        public string Date { get; set; }
        public string Text { get; set; }
    }
}
