﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EitaaGram.BotLib.Models
{
    public abstract class BaseModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
    }
}
