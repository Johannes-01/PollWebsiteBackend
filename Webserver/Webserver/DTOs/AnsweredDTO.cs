using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Webserver.Model;

namespace Webserver.DTOs
{
    public class AnswerDTO
    {
        [Required]
        public int SurveyID { get; set; }

        [Required]
        public int UserID { get; set; }

        [Required]
        public Poll Poll { get; set; }

        [Required]
        public int QuestionID { get; set; }

        [Required]
        public AnswerType AnswerType { get; set; }
    }
}
