using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace LegalMee.Models
{
	public class LegalitasApiModel
	{
		[JsonProperty("NombreWS")]
		public string NombreWS { get; set; }

		[JsonProperty("Metodo")]
		public string Metodo { get; set; }

		[JsonProperty("Parametros")]
		public List<LegalitasDataModel> Parametros { get; set; }

		[JsonProperty("Idioma")]
		public string Idioma { get; set; }

		[JsonProperty("TipoSalida")]
		public string TipoSalida { get; set; }
	}
}

