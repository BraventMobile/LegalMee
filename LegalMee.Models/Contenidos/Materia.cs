using System;
using Newtonsoft.Json;

namespace LegalMee.Models
{
	public class Materia
	{
		[JsonProperty("MateriaId")]
		public int MateriaId { get; set; }

		[JsonProperty("Nombre")]
		public string Nombre { get; set; }
	}
}

