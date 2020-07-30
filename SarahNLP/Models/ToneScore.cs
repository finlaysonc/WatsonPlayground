using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SarahNLP.Models
{
    public class ToneScore
    {
        public ToneScore()
        {
        }

        [Key]
        public int ToneScoreId { get; set; }

        public ToneType ToneType { get; set; }
        
        public int MessageId { get; set; }

        [ForeignKey(nameof(MessageId))]
        public Message Message { get; set; }

        public int? SmsMessageId {get;set;}  
        [ForeignKey(nameof(SmsMessageId))]
        public SmsMessage SmsMessage{get;set;}
        
        public double? Score { get; set; }
        
        public string ToneName { get; set; }    
    }
}