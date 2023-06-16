using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Webserver.Model
{
    public class Spinnerquestionoption
    {
        [Key, Required, NotNull]
        public int SpinnerquestionoptionID { get; set; }


        [Required, NotNull]
        public int Spinnerquestion { get; set; }


        public string Value { get; set; }

        [Required, NotNull]
        public string Heading { get; set; }

        public string Description { get; set; }

        public int Index { get; set; }

    }
}
