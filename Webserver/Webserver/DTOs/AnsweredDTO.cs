using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Webserver.Model;

namespace Webserver.DTOs
{
    public class AnswerDTO
    {
        [Required]
        public int UserID { get; set; }

        [Required]
        public int QuestionID { get; set; }

        [Required]
        public string Value { get; set; }
    }
}
