using System.ComponentModel.DataAnnotations.Schema;
using IBM.Watson.ToneAnalyzer.v3.Model;

namespace SarahNLP.Models
{
    [Table("ContentMessage")]
    public class ContentMessage : Message
    {
        public string ContentText { get; set; }
    }
}