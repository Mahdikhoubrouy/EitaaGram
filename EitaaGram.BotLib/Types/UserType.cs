namespace EitaaGram.Bot.Types
{
    public class UserType : BaseType
    {
        public bool is_bot { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public bool can_join_groups { get; set; }
        public bool can_read_all_group_messages { get; set; }
        public bool supports_inline_queries { get; set; }
    }
}
