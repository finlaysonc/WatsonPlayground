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
            ToneScores = new List<ToneScore>();
        }

        [Key]
        public int MessageId { get; set; }

        public DateTimeOffset Created { get; set; }

        [InverseProperty(nameof(ToneScore.Message))]
        public ICollection<ToneScore> ToneScores { get; set; }
    }
}