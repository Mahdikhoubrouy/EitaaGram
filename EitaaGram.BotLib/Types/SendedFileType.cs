using System;
using System.Collections.Generic;
using System.Text;

namespace EitaaGram.BotLib.Types
{
    public class SendedFileType
    {
        public UserType from { get; set; }
        public ChatType channel { get; set; }
    }
}
