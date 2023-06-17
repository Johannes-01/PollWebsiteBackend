    using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Webserver.Model
{
    /// <summary>
    /// Function as a votes relationship table
    /// </summary>
    public class Answer
    {
        [Key]
        public int AnswerID { get; set; }

        [Required]
        public int SurveyID { get; set; }

        [Required]
        public int UserID { get; set; }

        [Required]
        public int QuestionId { get; set; }

        [Required]
        public AnswerType AnswerType { get; set; }
    }
}

public enum AnswerType
{
    Textanswer = 0,
    Intanswer = 1,
}