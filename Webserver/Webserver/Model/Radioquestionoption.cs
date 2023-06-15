using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Webserver.Model
{
    public class Radioquestionoption
    {
        [Key, Required]
        public int RadioquestionoptionID { get; set; }
        
        [Required]
        public int RadioquestionID { get; set; }

        [Required, NotNull]
        public string Value { get; set; }


        public int Index { get; set; }
    }
}
