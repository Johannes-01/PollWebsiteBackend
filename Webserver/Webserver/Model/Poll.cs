using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Webserver.Model
{
    public class Poll
    {
        [Key, Required]
        public int PollID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [ForeignKey("UserID")]
        public int UserID { get; set; }

        public DateTime Created { get; set; }
        
        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }    
    }
}
