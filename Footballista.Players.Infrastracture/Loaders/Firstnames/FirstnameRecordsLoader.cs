using CsvHelper;
using Footballista.Players.Infrastracture.Loaders.Firstnames.ClassMaps;
using Footballista.Players.Infrastracture.Loaders.Firstnames.Records;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Footballista.Players.Infrastracture.Loaders.Firstnames
{

	public class FirstnameRecordsLoader : IFirstnameRecordsLoader
	{
		private readonly IHostEnvironment _hostEnvironment;
		private readonly string _folderPath = @"..\data\firstnames";
		private readonly string _filename = "firstnames-2014.csv";
		private string FullPath => Path.GetFullPath(string.Concat
		(
			_hostEnvironment.ContentRootPath,
			_hostEnvironment.ContentRootPath.EndsWith(@"\") ? "" : @"\",
			_folderPath, @"\",
			_filename
		));

		public FirstnameRecordsLoader(IHostEnvironment hostEnvironment)
		{
			_hostEnvironment = hostEnvironment;
		}
		public List<FirstnameRecord> GetRecords()
		{
			List<FirstnameRecord> result;
			using (var reader = new StreamReader(FullPath))
			using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
			{
				csv.Configuration.RegisterClassMap<FirstnameRecordClassMap>();
				csv.Configuration.Delimiter = ";";
				csv.Configuration.Encoding = Encoding.UTF8;

				result = csv.GetRecords<FirstnameRecord>().ToList();
			}
			return result;
		}
	}
}
