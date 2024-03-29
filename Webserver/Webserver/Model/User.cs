﻿using System.ComponentModel.DataAnnotations;

namespace Webserver.Model
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        

        public string Email { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }

        public string Role { get; set; }


    }
}