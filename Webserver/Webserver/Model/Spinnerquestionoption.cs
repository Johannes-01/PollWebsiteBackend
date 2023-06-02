using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Webserver.Model
{
    public class Spinnerquestionoption
    {
        [Key]
        public int SpinnerquestionoptionID { get; set; }
        [Required, NotNull]
        public int Spinnerquestion { get; set; }
        [Required, NotNull]

        public string Value { get; set; }

        public string Heading { get; set; }
        [Required, NotNull]

        public string Description { get; set; }

        public int Index { get; set; }

    }
}
