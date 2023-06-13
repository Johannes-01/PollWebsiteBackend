using System.ComponentModel.DataAnnotations;

namespace Webserver.Model
{
    public class Poll
    {
        [Key]
        public int PollID { get; set; }
        [Required]

        public string Title { get; set; }

        public string Description { get; set; }

        public int UserID { get; set; }

        public DateTime Created { get; set; }
        
        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    
        public User[] Voters { get; set; }
    }
}
