using System;
using Newtonsoft.Json;

namespace LegalMee.Models
{
	public class ApiUser
	{
		[JsonProperty("userId")]
		public string UserId { get; set; }

		[JsonProperty("userPassword")]
		public string UserPassword { get; set; }

		[JsonProperty("userPlatform")]
		public string UserPlatform { get; set; }
	}
}

