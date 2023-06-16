using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;


namespace Webserver.DTOs
{
	public class LoginRequestDto
	{
		public LoginRequestDto()
		{
			[Required]
			public int LoginId { get; set; }

			[Required]
			public string Username { get; set; }

			[Required]
			public string Password { get; set; }
		}
	} 
}
