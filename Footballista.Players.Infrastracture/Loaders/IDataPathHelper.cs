using Microsoft.Extensions.Hosting;
using System;
using System.IO;

namespace Footballista.Players.Infrastracture.Loaders
{
	public interface IDataPathHelper
	{
		string GetFullPath(string folderPath, string filename);
	}
	public class DataPathHelper : IDataPathHelper
	{
		private readonly IHostEnvironment _hostEnvironment;

		public DataPathHelper(IHostEnvironment hostEnvironment)
		{
			_hostEnvironment = hostEnvironment;
		}

		public string GetFullPath(string folderPath, string filename)
		{
			if (string.IsNullOrEmpty(folderPath)) throw new ArgumentException(nameof(folderPath));
			if (string.IsNullOrEmpty(filename)) throw new ArgumentException(nameof(filename));

			return Path.GetFullPath(string.Concat
			(
				_hostEnvironment.ContentRootPath,
				_hostEnvironment.ContentRootPath.EndsWith(@"\") ? "" : @"\",
				@"..\",
				folderPath, @"\",
				filename
			));
		}
	}
}
