using System;
using Newtonsoft.Json;

namespace LegalMee.Models
{
	public class Contenido
	{
		[JsonProperty("SubMateriaId")]
		public int SubMateriaId { get; set; }

		[JsonProperty("ZonaId")]
		public int ZonaId { get; set; }

		[JsonProperty("PaisId")]
		public int PaisId { get; set; }

		[JsonProperty("Titulo")]
		public string Title { get; set; }

		[JsonProperty("Texto")]
		public string Text { get; set; }

		[JsonProperty("Url")]
		public string Url { get; set; }

		[JsonProperty("Direccion")]
		public string Direccion { get; set; }

		[JsonProperty("Telefono")]
		public string Telefono { get; set; }

		[JsonProperty("Version")]
		public int Version { get; set; }

		[JsonProperty("Documentos")]
		public object[] Documentos { get; set; }

		[JsonIgnore]
		public string Matter { get; set; }

		[JsonIgnore]
		public string SubMatter { get; set; }
	}
}

