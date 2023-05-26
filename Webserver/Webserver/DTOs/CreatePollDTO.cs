using System.ComponentModel.DataAnnotations;

namespace Webserver.DTOs
{
    public class CreatePollDto
    {
        [Key]
        public int PollID { get; set; }
        [Required]

        public string Title { get; set; }

        public string Description { get; set; }

        public int Author { get; set; }

        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        public DateTime startDate { get; set; }

        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        public DateTime endDate { get; set; }

        //public int answeredID { get; set; }
    }
}
