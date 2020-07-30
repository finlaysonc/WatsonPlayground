using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;

namespace SarahNLP.Models
{
    public class SmsMessage
    {
        public SmsMessage()
        {
         //   ToneScores = new List<ToneScore>();
        }

        public int SmsMessageId { get; set; }

        public string MessageText { get; set; }

        public string User { get; set; }

        public DateTimeOffset Created { get; set; }

        public int MessageId { get; set; }

        [ForeignKey(nameof(MessageId))]
        public SmsThread SmsThread { get; set; }

        [InverseProperty(nameof(ToneScore.SmsMessage))]
        public ICollection<ToneScore> ToneScores { get; set; }
    }
}