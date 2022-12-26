namespace EitaaGram.BotLib.Types
{
    public class MessageType
    {
        public string message_id { get; set; }
        public UserType from { get; set; }
        public ChatType chat { get; set; }
        public string date { get; set; }
        public string text { get; set; }
    }
}
