using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SarahNLP.Models;

namespace SarahNLP.Models
{
    [Table("Messages")]
    public abstract class Message
    {
        [Key]
        public int MessageId { get; set; }

        public DateTimeOffset Craeted { get; set; }

        public ICollection<ToneScore> ToneScores{  get; set; }
    }
}