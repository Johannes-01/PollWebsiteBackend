using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Webserver.Model
{
    public class Sliderquestion
    {
        [Key]
        public int SliderquestionID { get; set; }
        [Required]

        public int SurveyID { get; set;}
        [Required, NotNull]

        public string Heading { get; set; }
        [Required, NotNull]

        public string Description { get; set; }

        public int Index { get; set; }
    }
}
