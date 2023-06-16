using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Webserver.Model
    {
        public class Textanswer
        {
        [Key, Required, NotNull]
        public int TextanswerID { get; set; }

        public int Index { get; set; }

        [Required]
        public int Value { get; set; }
        

        }
    }
