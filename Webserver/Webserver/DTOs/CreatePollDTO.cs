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

        public List<QuestionsDto>? questions { get; set; }
    }
}

/*{
  "title": "My Poll",
  "description": "Description of my poll",
  "author": null,
  "startDate": null,
  "endDate": null,
  "questions": [
    {
      "index": 0,
      "type": 2,
      "value": [
        "option 1",
        "new option",
        "option 3",
        "option 2",
      ],
    },
    {
      "index": 1,
      "type": 1,
      "value": "ksldjf lskdj sdlf.",
    },
    {
      "index": 2,
      "type": 0,
      "value": "44",
    },
  ],
}*/