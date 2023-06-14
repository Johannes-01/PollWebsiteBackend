using System.ComponentModel.DataAnnotations;

namespace Webserver.Model
{
    public class QuestionsOnPoll
    {
        [Key, Required]
        public int QuestionOnPollId { get; set; }

        [Required]
        public int PollId { get; set; }


        [Required]
        public int QuestionId { get; set; }
    }
}
