using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Webserver.Model
{
    public class Poll
    {
        [Key, Required]
        public int PollID { get; set; }
        

        public string Title { get; set; }

        public string Description { get; set; }

        [Required, ForeignKey(nameof(UserID))]
        public int UserID { get; set; }
        
        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    
        public User[] Voters { get; set; }
    }
}
