using System;
using System.Threading.Tasks;

namespace LegalMee.Services
{
	public interface IFileService
	{
		Task<bool> Exists (string filename);

		Task SaveFile<T> (T input, string filename) where T : class;

		Task<T> GetFile<T> (string filename) where T : class;
	}
}

