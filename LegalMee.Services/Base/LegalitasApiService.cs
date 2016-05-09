using System;
using Xamarin.Forms;
using System.Threading.Tasks;
using Plugin.Connectivity;
using System.Net.Http;
using LegalMee.Models;
using Newtonsoft.Json;
using System.Text;
using System.Collections.Generic;
using RockMvvmForms;

namespace LegalMee.Services
{
	public class LegalitasApiService
	{
		private const string url = "https://ws.legalitas.com/swapps/api/legalitassw";
		private const string apiUser = "TEST";
		private const string apiUserPassword = "TEST";
		private const string apiUserPlatform = "TESTAPPS";

		private readonly IFileService _fileservice;

		public LegalitasApiService ()
		{
			_fileservice = RockServiceLocator.Current.Get<IFileService>();
		}


		#region Post

		public async Task<TResult> Post<TResult> (
			string nombreWS, 
			string method, 
			string filename, 
			bool forceLocal,
			params object[] data) where TResult : class
		{
			try {

				TResult result = default(TResult);


				// We will make the call only if there's connexion
				bool callApi = true;
				if (!CrossConnectivity.Current.IsConnected)
				{
					callApi = false;
				}
				else if (forceLocal)
				{
					// We will force the api to get the data from local if it is indicated on the call and the file exist
					if (!string.IsNullOrEmpty(filename))
					{
						var exists = await _fileservice.Exists(filename);
						if (exists)
							callApi = false;
					}
				}

				if (callApi)
				{
					HttpClient client = new HttpClient ();
					HttpContent content = null;

					LegalitasApiModel apiModel = new LegalitasApiModel () {
						Idioma = "ES",
						Metodo = method,
						NombreWS = nombreWS,
						TipoSalida = "json",
						Parametros = new List<LegalitasDataModel> ()
					};

					// Authentication 
					ApiUser user = new ApiUser () {
						UserId = apiUser,
						UserPassword = apiUserPassword,
						UserPlatform = apiUserPlatform
					};
					apiModel.Parametros.Add (new LegalitasDataModel () {
						Name = "ApiUser",
						Data = user
					});

					foreach (var input in data) {
						if (input != null) {
							LegalitasDataModel dataItem = new LegalitasDataModel () {
								Name = input.GetType ().Name,
								Data = input
							};
							apiModel.Parametros.Add (dataItem);
						}
					}

					string scontent = JsonConvert.SerializeObject (apiModel);
					content = new StringContent (scontent, Encoding.UTF8, "application/json");

					HttpResponseMessage response = new HttpResponseMessage ();
					response = await client.PostAsync (url, content);

					if (response.IsSuccessStatusCode) {
						string responseText = await response.Content.ReadAsStringAsync ();
						LegalitasApiResponse apiResponse = JsonConvert.DeserializeObject<LegalitasApiResponse> (responseText);
						// Check the generic error messages of the Legalitas API
						if (scontent.Contains ("alertasCliente")) {
							if (apiResponse.Codigo.Equals ("142")) { //Returns "Usuario no encontrado" when  user doesn't have any notification
								result = null;
							} else if (apiResponse.Codigo.Equals ("1") || apiResponse.Codigo.Equals ("301") || apiResponse.Codigo.Equals ("401") || apiResponse.Codigo.Equals ("315")) {

								if (apiResponse.Resultado != null)
									result = JsonConvert.DeserializeObject<TResult>(apiResponse.Resultado.ToString());
								else
									result = null;

								// Save result in file if it has been indicated
								if (!string.IsNullOrEmpty(filename))
								{
									await _fileservice.SaveFile<TResult>(result, filename);
								}

							}
							else
							{
								if(!CrossConnectivity.Current.IsConnected)
									throw new Exception("Sin conexión a internet");
								else
									throw new Exception (String.Format ("{0}: {1}", apiResponse.Codigo, apiResponse.Mensaje));
							}
						} else if (scontent.Contains ("ConsultasCliente") && apiResponse.Mensaje == "Fallo al recuperar consultas" && apiResponse.Resultado == null) {
							result = null;
						} else {
							if (apiResponse.Codigo.Equals ("1") || apiResponse.Codigo.Equals ("301") || apiResponse.Codigo.Equals ("401") || apiResponse.Codigo.Equals ("315") || apiResponse.Codigo.Equals ("0") || apiResponse.Codigo.Equals ("501")) {
								if (apiResponse.Resultado == null)
									result = null;
								else
								{
									var z = apiResponse.Resultado;
									var x = apiResponse.Resultado.ToString();
									result = JsonConvert.DeserializeObject<TResult>(x);
								}

							}
							else
							{
								if (!CrossConnectivity.Current.IsConnected)
									throw new Exception("Sin conexión a internet");
								else
									throw new Exception (String.Format ("{0}: {1}", apiResponse.Codigo, apiResponse.Mensaje));
							}
						}

						// Save the file if we indicate the name
						if ((result != null) && (!string.IsNullOrEmpty(filename)))
						{
							await _fileservice.SaveFile<TResult>(result, filename);
						}

					}
				}
				else
				{
					// Get the data saved 
					if (!string.IsNullOrEmpty(filename))
						result = await _fileservice.GetFile<TResult>(filename);
				}

				return result;

			} catch (Exception ex) {
				if (!CrossConnectivity.Current.IsConnected)
					throw new Exception("Sin conexión a internet");
				else
					throw ex;
			}

		}

		#endregion
	}
}

