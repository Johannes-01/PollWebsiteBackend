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
    
        public User Author { get; set; }
        
        public DateTime? startDate { get; set; }

        public DateTime? endDate { get; set; }
    
        public User[] Voters { get; set; }
    }
}
