using System;
using Newtonsoft.Json;

namespace LegalMee.Models
{
	public class LegalitasDataModel
	{
		[JsonProperty("nombre")]
		public string Name { get; set; }

		[JsonProperty("datos")]
		public object Data { get; set; }
	}
}

