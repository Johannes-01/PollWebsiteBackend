using System.ComponentModel.DataAnnotations;

    namespace Webserver.Model
    {
    public class Answered
    {
        [Key]
        public int AnsweredID { get; set;}
        [Required]

        public int SurveyID { get; set;}
        [Required]

        public int[] UserID { get; set;}
        [Required]

        }
    }
