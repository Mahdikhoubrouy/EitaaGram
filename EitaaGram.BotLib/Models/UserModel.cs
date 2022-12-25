using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EitaaGram.BotLib.Models
{
    public class UserModel : BaseModel
    {
        public bool is_bot { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public bool can_join_groups { get; set; }
        public bool can_read_all_group_messages { get; set; }
        public bool supports_inline_queries { get; set; }
    }
}
