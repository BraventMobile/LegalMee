using System;
using Newtonsoft.Json;

namespace LegalMee.Models
{
	public class SubMateria
	{
		[JsonProperty("SubmateriaId")]
		public int SubmateriaId { get; set; }

		[JsonProperty("MateriaId")]
		public int MateriaId { get; set; }

		[JsonProperty("Nombre")]
		public string Nombre { get; set; }
	}
}

