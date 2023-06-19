using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Webserver.Model
{
    public class Sliderquestion
    {
        [Key, Required]
        public int SliderquestionID { get; set; }
        
        [Required, NotNull]
        public int SurveyID { get; set;}

        [Required, NotNull]
        public string Heading { get; set; }


        public string Description { get; set; }

        public int Index { get; set; }
    }
}
