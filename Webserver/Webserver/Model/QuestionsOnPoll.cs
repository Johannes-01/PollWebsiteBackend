using System.ComponentModel.DataAnnotations;

namespace Webserver.Model
{
    public class QuestionsOnPoll
    {
        [Required]
        public int PollId { get; set; }


        [Required]
        public int QuestionId { get; set; }
    }
}
