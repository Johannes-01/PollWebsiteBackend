using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Webserver.Model;

namespace Webserver.DTOs
{
    public class AnsweredDTO
    {
        [Required]
        public int AnsweredID { get; set; }

        [Required]
        public int SurveyID { get; set; }

        [Required]
        public int[] UserID { get; set; }

        [Required]
        public Poll Poll { get; set; }
    }
}
