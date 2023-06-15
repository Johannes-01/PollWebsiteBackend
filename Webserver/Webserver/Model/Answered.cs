using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Webserver.Model
    {
    public class Answered
    {
        [Key, Required]
        public int AnsweredID { get; set;}

        [Required, ForeignKey(nameof(Poll))]
        public int SurveyID { get; set;}

        [Required, ForeignKey(nameof(UserID))]
        public int[] UserID { get; set;}

        [Required, NotNull]
        public Poll Poll { get; set;}
        }
    }
