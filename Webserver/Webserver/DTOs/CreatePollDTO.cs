using System.ComponentModel.DataAnnotations;

namespace Webserver.DTOs
{
    public class CreatePollDto
    {
        [Required]
        public string Title { get; set; }
        
        [Required]
        public string Description { get; set; }
        
        [Required]
        public int Author { get; set; }

        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        public DateTime startDate { get; set; }

        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        public DateTime endDate { get; set; }
    }
}
