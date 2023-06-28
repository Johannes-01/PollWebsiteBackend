using System.ComponentModel.DataAnnotations;

namespace Webserver.Model
{
    public class Question
    {
        [Key]
        public int QuestionID { get; set; }
        
        [Required]
        public string Heading { get; set; }

        public int PollID { get; set; }

        public string? Description { get; set; }

        /// <summary>
        /// Index - shows the order the Questions gets displayed in the Poll.
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// Determines the Question type.
        /// </summary>
        public QuestionType QuestionType { get; set; }   
    }

    public enum QuestionType
    {
        TextQuestion = 1,

        MultipleChoiceQuestion = 2,

        SliderQuestion = 0,
    }
}