using System.ComponentModel.DataAnnotations;

    namespace Webserver.Model
    {
    /// <summary>
    /// Function as a votes relationship table
    /// </summary>
    public class Answers
    {
        [Key, Required]
        public int AnsweredID { get; set;}
        
        [Required]
        public int SurveyID { get; set;}

        [Required]
        public int[] UserID { get; set;}
        }
    }
