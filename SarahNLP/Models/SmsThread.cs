using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SarahNLP.Models
{
    public class SmsThread : Message
    {
        public SmsThread()
        {
            SmsMessages = new List<SmsMessage>();
        }

        [InverseProperty(nameof(SmsMessage.SmsThread))]
        public ICollection<SmsMessage> SmsMessages { get; set; }
    }
}