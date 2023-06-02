using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Webserver.Model
{
    public class Radioquestionoption
    {
        [Key]
        public int RadioquestionoptionID { get; set; }
        [Required]
        
        public int RadioquestionID { get; set; }
        [Required]

        public string Value { get; set; }
        [Required, NotNull]

        public int Index { get; set; }
    }
}
