namespace SarahNLP.Models
{
    public class Message
    {
        public int MessageId { get; set; }
        public MessageType MessageType { get; set; }
        public string MessageText { get; set; }
    }
}