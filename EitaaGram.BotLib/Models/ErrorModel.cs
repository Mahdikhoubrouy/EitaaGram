using System;
using System.Collections.Generic;
using System.Text;

namespace EitaaGram.BotLib.Models
{
    public class ErrorModel
    {
        public int error_code { get; set; }
        public string description { get; set; }
        public bool ok { get; set; }
    }
}
