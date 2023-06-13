using System.ComponentModel.DataAnnotations;

namespace Webserver.DTOs
{
    public class QuestionsDto
    {
        public string? Description { get; set; }

        [Required]
        public string? Heading { get; set; }

        public int Index { get; set; }

        public int Type { get; set; }
    }
}