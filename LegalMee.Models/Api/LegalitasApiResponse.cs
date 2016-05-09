using System;
using Newtonsoft.Json;

namespace LegalMee.Models
{
	public class LegalitasApiResponse
	{
		[JsonProperty("Codigo")]
		public string Codigo { get; set; }

		[JsonProperty("Mensaje")]
		public string Mensaje { get; set; }

		[JsonProperty("Resultado")]
		public object Resultado { get; set; }
	}
}

