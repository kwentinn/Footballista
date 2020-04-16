using CsvHelper;
using Footballista.Players.Infrastracture.Loaders.Cities.ClassMaps;
using Footballista.Players.Infrastracture.Loaders.Cities.Records;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Footballista.Players.Infrastracture.Loaders.Cities
{
	public class WorldCitiesLoader : IWorldCitiesLoader
	{
		private readonly IHostEnvironment _hostEnvironment;
		private readonly string _folderPath = @"..\data\cities";
		private readonly string _filename = "worldcities.csv";
		private string FullPath => Path.GetFullPath(string.Concat
		(
			_hostEnvironment.ContentRootPath,
			_hostEnvironment.ContentRootPath.EndsWith(@"\") ? "" : @"\",
			_folderPath, @"\",
			_filename
		));

		public WorldCitiesLoader(IHostEnvironment hostEnvironment)
		{
			_hostEnvironment = hostEnvironment;
		}

		public List<WorldCityRecord> GetRecords()
		{
			List<WorldCityRecord> result;
			using (var reader = new StreamReader(FullPath))
			using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
			{
				csv.Configuration.RegisterClassMap<WorldCityRecordClassMap>();
				csv.Configuration.Delimiter = ",";
				csv.Configuration.Encoding = Encoding.UTF8;
				csv.Configuration.BadDataFound = null;

				result = csv.GetRecords<WorldCityRecord>().ToList();
			}
			return result;
		}
	}
}
