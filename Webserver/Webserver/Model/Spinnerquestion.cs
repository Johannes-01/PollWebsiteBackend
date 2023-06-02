using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Webserver.Model
{
    public class Spinnerquestion
    {
        [Key]
        public int SpinnerquestionID { get; set; }
        [Required]

        public int PollID { get; set; }
        [Required]

        public string Heading { get; set; }
        [Required, NotNull]

        public string Description { get; set; }

        public int Index { get; set; }
    }
}
