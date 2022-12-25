using System;
using System.Collections.Generic;
using System.Text;

namespace EitaaGram.BotLib.Types
{
    public class ErrorType
    {
        public int error_code { get; set; }
        public string description { get; set; }
        public bool ok { get; set; }
    }
}
