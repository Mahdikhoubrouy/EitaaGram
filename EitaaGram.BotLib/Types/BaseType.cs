using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EitaaGram.BotLib.Types
{
    public abstract class BaseType
    {
        public int id { get; set; }
        public string username { get; set; }
    }
}
