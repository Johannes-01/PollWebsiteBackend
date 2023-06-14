using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Webserver.Model
{
    public class TextAnswer
    {
        [ForeignKey("AnsweredID")]
        public int AnsweredID { get; set; }

        [Key]
        public int TextAnswerID { get; set; }

        [Required]
        public int SurveyID { get; set; }

        [Required]
        public string Heading { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Index { get; set; }
    }
}
