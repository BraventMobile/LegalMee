using System;
using PCLStorage;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LegalMee.Services
{
	public class FileService: IFileService
	{
		private readonly IFolder _folderService;

		public FileService ()
		{
			_folderService = FileSystem.Current.LocalStorage;
		}

		#region Exists

		public async Task<bool> Exists (string filename)
		{
			var exists = await _folderService.CheckExistsAsync(filename);
			if (exists == ExistenceCheckResult.FileExists)
			{
				return true;
			}
			return false;
		}

		#endregion

		#region SaveFile

		public async Task SaveFile<T> (T input, string filename) where T : class
		{
			IFile file = await _folderService.CreateFileAsync (filename,
				CreationCollisionOption.ReplaceExisting);

			await file.WriteAllTextAsync (JsonConvert.SerializeObject (input)); 
		}


		#endregion

		#region GetFile

		public async Task<T> GetFile<T> (string filename) where T : class
		{

			T output = default(T);
			ExistenceCheckResult exists = await _folderService.CheckExistsAsync(filename);
			if (exists == ExistenceCheckResult.FileExists)
			{
				IFile file = await _folderService.GetFileAsync(filename);

				string value = await file.ReadAllTextAsync();
				output = JsonConvert.DeserializeObject<T>(value);
			}
			return output;

		}

		#endregion
	}
}

