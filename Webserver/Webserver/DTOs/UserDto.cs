using System.ComponentModel.DataAnnotations;

namespace Webserver.DTOs
{
    public class UserDto
    {
        public int UserID { get; set; }

        public string Email { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }

        public string Role { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
