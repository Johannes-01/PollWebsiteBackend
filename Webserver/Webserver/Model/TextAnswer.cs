using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Webserver.Model
{
    public class TextAnswer
    {
<<<<<<< HEAD:Webserver/Webserver/Model/TextAnswer.cs
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
=======
        public class Textquestion
        {
            [Key, Required]
            public int TextquestionID { get; set; }
        
            [Required]
            public int SurveyID { get; set;}
        
            [Required]
            public string Heading { get; set; }
        

            public string Description { get; set; }

            public int Index { get; set; }
        }
>>>>>>> New-DTOs:Webserver/Webserver/Model/Textquestion.cs
    }
}
