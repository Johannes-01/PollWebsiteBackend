using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Webserver.Model
    {
        public class Radioquestion
        {
        [Key]
        public int RadioquestionID { get; set; }
        [Required]

        public int SurveyID { get; set; }
        [Required]

        public string Heading { get; set; }
        [Required, NotNull]

        public string Description { get; set; }
        
        public int Index { get; set; }
        }
    }
