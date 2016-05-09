using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace LegalMee.Models
{
	public class ContenidoResult
	{
		[JsonProperty("Contenidos")]
		public List<Contenido> Contenidos {get;set;}

		[JsonProperty("Materias")]
		public List<Materia> Materias { get; set; }

		[JsonProperty("SubMaterias")]
		public List<SubMateria> SubMaterias { get; set; }
	}
}

