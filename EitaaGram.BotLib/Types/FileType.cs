namespace EitaaGram.Bot.Types
{
    public class FileType
    {
        public string message_id { get; set; }
        public UserType from { get; set; }
        public string date { get; set; }
        public string text { get; set; }
    }
}
