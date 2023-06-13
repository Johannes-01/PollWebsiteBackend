using System.ComponentModel.DataAnnotations;

namespace Webserver.Model
{
    public class Question
    {
        [Key]
        public int id { get; set; }
        [Required]

        public string heading { get; set; }

        public int survey_id { get; set; }

        public string? description { get; set; }

        public int index { get; set; }

        public int type { get; set; }
    }
}