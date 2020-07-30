using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SarahNLP.Models;

namespace SarahNLP.Models
{
    public class Message
    {
        public Message()
        {
        }

        [Key]
        public int MessageId { get; set; }

        public DateTimeOffset Craeted { get; set; }

        //[InverseProperty(nameof(ToneScore.Message))]
        //public ICollection<ToneScore> ToneScoresMessages {get; set; }
    }
}