using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Webserver.Model
{
    /// <summary>
    /// Function as a votes relationship table
    /// </summary>
    public class Answer
    {
        [Key]
        public int AnswerID { get; set; }

        [Required]
        public int UserID { get; set; }

        [Required]
        public int QuestionID { get; set; }

        [Required]
        public string Value { get; set; }

        /// <summary>
        /// For when the question is an multiplechoice type and you pass the index you picked. --> Not sure if necassary?
        /// </summary>
        //public int Index { get; set; }
    }
}