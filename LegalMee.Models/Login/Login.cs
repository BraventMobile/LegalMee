using System;
using Newtonsoft.Json;

namespace LegalMee.Models
{
	public class Login
	{
		[JsonProperty("email")]
		public string Email { get; set; }

		[JsonProperty("password")]
		public string Password { get; set; }

		[JsonProperty("source")]
		public string Source { get; set; }
	}
}

