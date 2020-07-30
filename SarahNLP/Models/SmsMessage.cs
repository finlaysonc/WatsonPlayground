using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SarahNLP.Models
{
    [Table("SmsMessage")]
    public class SmsMessage
    {
        public SmsMessage()
        {
        }

        public int SmsMessageId { get; set; }
        public string MessageText { get; set; }
        public string User { get; set; }
        public DateTimeOffset Created { get; set; }

        [ForeignKey("MessageId")]
        public SmsThread SmsThread { get; set; }
    }
}