using System.ComponentModel.DataAnnotations;

namespace Webserver.DTOs
{
    public class CreatePollDto
    {
        [Required]
        public string Title { get; set; }
        
        [Required]
        public string Description { get; set; }
        
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        public DateTime startDate { get; set; }

        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        public DateTime endDate { get; set; }

        public List<QuestionsDto>? questions { get; set; }
    }

    /*
 {
  "title": "test for multiple choice",
  "description": "long textlong textlong textlong textlong textlong textlong text",
  "author": 0,
  "startDate": "2023-06-14T06:43:49.022Z",
  "endDate": "2023-07-14T06:43:49.022Z",
  "questions": [
    {
      "index": 0,
      "type": 2,
      "heading": "Multiple choice question1",
      "description": "Optional Text",
      "value": [
        "multiple choice opt1",
        "multiple choice opt2",
        "multiple choice otp3"
      ]
    }
  ]
}
    */
}