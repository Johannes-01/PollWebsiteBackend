using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Webserver.Model
    {
        public class Radioquestion
        {
        [Key, Required]
        public int RadioquestionID { get; set; }

        [Required]
        public int SurveyID { get; set; }
        
        [Required, NotNull]
        public string Heading { get; set; }
        

        public string Description { get; set; }
        
        public int Index { get; set; }
        }
    }
