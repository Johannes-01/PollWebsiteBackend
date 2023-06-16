using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Webserver.Model
{
    public class Spinnerquestion
    {
        [Key, Required]
        public int SpinnerquestionID { get; set; }
        
        [Required, ForeignKey(nameof(Poll))]
        public int PollID { get; set; }

        [Required, NotNull]
        public string Heading { get; set; }


        public string Description { get; set; }

        public int Index { get; set; }
    }
}
