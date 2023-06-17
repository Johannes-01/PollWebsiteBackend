using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Webserver.Model;

namespace Webserver.DTOs
{

	public class IntanswerDto
	{
			[Required]
			public int IntanswerID { get; set; }

			public int Index { get; set; }

			[Required]
			public int Value { get; set; }
		}
	}

