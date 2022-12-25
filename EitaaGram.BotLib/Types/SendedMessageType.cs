using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EitaaGram.BotLib.Types
{
    public class SendedMessageType
    {
        public string message_id { get; set; }
        public UserType from { get; set; }
        public ChatType chat { get; set; }
        public string date { get; set; }
        public string text { get; set; }
    }
}
