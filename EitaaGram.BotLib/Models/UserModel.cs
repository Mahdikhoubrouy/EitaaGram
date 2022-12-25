using System;
using System.Collections.Generic;
using System.Text;

namespace EitaaGram.BotLib.Models
{
    public class UserModel : BaseModel
    {
        public bool IsBot { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
