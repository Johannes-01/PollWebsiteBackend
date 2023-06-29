using System.ComponentModel.DataAnnotations;
using Webserver.Model;

namespace Webserver.DTOs
{
    public class QuestionsDto
    {
        public string? Description { get; set; }

        [Required]
        public string? Heading { get; set; }

        public int Index { get; set; }

        public QuestionType Type { get; set; }

        public string[]? value { get; set; }
    }
}