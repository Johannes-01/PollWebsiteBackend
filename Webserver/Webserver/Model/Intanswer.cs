using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Webserver.Model
{
    public class IntAnswer
    {
        public int AnswerID { get; set; }

        [Key]
        public int IntAnswerID { get; set; }

        [Required]
        public int Index { get; set; }

        [Required]
        public int Value { get; set; }

        [Required]
        public string Heading { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
