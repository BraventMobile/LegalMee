using System;
using Newtonsoft.Json;

namespace LegalMee.Models
{
	public class Colectivo
	{
		[JsonProperty("code")]
		public string Code { get; set; }
	}
}

