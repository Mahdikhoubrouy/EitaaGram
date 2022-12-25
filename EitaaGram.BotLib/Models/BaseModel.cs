using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EitaaGram.BotLib.Models
{
    public abstract class BaseModel
    {
        public int id { get; set; }
        public string username { get; set; }
    }
}
