using System.ComponentModel.DataAnnotations;

namespace Webserver.Model
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        [Required]

        public string Email { get; set; }

        public string Firstname { get; set; }

        public User Lastname { get; set; }

        public DateOnly BirthDate { get; set; }

        public string Role { get; set; }


    }
}