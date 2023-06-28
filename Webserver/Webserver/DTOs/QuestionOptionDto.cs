using System.ComponentModel.DataAnnotations;
using Webserver.Model;

namespace Webserver.DTOs
{
    public class QuestionOptionDto
    {
        [Required]
        public string Value { get; set; }
    }
}