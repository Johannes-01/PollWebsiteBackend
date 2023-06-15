using System.ComponentModel.DataAnnotations;

    namespace Webserver.Model
    {
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
    }
