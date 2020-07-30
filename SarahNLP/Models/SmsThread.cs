using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SarahNLP.Models
{
    [Table("SmsMessage")]
    public class SmsThread : Message
    {
        public SmsThread()
        {
            SmsMessages = new List<SmsMessage>();
        }

        [InverseProperty("SmsThread")]
        public ICollection<SmsMessage> SmsMessages { get; set; }
    }
}