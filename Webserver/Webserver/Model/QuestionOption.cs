using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Webserver.Model
{
    public class QuestionOption
    {
        [Key]
        public int QuestionOptionId { get; set; }

        [ForeignKey("QuestionID")]
        public int QuestionID { get; set; }

        [Required]
        public string Value { get; set; }
    }
}
