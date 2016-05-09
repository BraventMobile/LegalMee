using System;
using Newtonsoft.Json;

namespace LegalMee.Models
{
	public class Cliente
	{
		[JsonProperty("ID")]
		public string ID { get; set; }

		[JsonProperty("email")]
		public string Email { get; set; }

		[JsonProperty("telephone")]
		public string Telephone { get; set; }

		[JsonProperty("login")]
		public Login Login { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("lastname1")]
		public string Lastname1 { get; set; }

		[JsonProperty("lastname2")]
		public string Lastname2 { get; set; }

		[JsonProperty("gender")]
		public string Gender { get; set; }

		[JsonProperty("dob")]
		public string Dob { get; set; }

		[JsonProperty("documentNumber")]
		public string DocumentNumber { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }

		[JsonProperty("TipoUsuario")]
		public string UserType { get; set; }

		[JsonProperty("companyName")]
		public string CompanyName { get; set; }
	}
}

