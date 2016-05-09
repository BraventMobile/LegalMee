using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using LegalMee.Models;

namespace LegalMee.Services
{
	public class FaqsService: LegalitasApiService, IFaqsService
	{
		public Task<ContenidoResult> GetFrequentQuestion(Cliente cliente, Colectivo colectivo)
		{
			try
			{
				return Post<ContenidoResult>(LegalitasWS.CONTENIDOS, "GetAllContenidos", LocalFileRoutes.FILE_FAQS, false, cliente, colectivo);
			}
			catch (Exception ex)
			{
				throw ex;
			}

		}
	}
}

