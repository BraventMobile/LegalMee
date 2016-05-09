using System;
using LegalMee.Models;
using System.Threading.Tasks;

namespace LegalMee.Services
{
	public interface IFaqsService
	{
		Task<ContenidoResult> GetFrequentQuestion (Cliente cliente, Colectivo colectivo);
	}
}

