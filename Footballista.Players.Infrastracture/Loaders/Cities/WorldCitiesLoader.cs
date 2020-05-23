using CsvHelper;
using Footballista.BuildingBlocks.Domain;
using Footballista.Players.Infrastracture.Loaders.Cities.ClassMaps;
using Footballista.Players.Infrastracture.Loaders.Cities.Records;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footballista.Players.Infrastracture.Loaders.Cities
{
	public class WorldCitiesLoader : IWorldCitiesLoader
	{
		private readonly string _folderPath = @"..\data\cities";
		private readonly string _filename = "worldcities.csv";
		private readonly IDataPathHelper _dataPathHelper;

		public WorldCitiesLoader(IDataPathHelper dataPathHelper)
		{
			_dataPathHelper = dataPathHelper;
		}

		public Maybe<List<WorldCityRecord>> GetRecords()
		{
			List<WorldCityRecord> result;
			string fullPath = _dataPathHelper.GetFullPath(_folderPath, _filename);
			using (var reader = new StreamReader(fullPath))
			using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
			{
				csv.Configuration.RegisterClassMap<WorldCityRecordClassMap>();
				csv.Configuration.Delimiter = ",";
				csv.Configuration.Encoding = Encoding.UTF8;
				csv.Configuration.BadDataFound = null;

				result = csv.GetRecords<WorldCityRecord>().ToList();
			}
			return Maybe.Some(result);
		}

		public async Task<Maybe<List<WorldCityRecord>>> GetRecordsAsync()
		{
			List<WorldCityRecord> result;
			string fullPath = _dataPathHelper.GetFullPath(_folderPath, _filename);
			using (var reader = new StreamReader(fullPath))
			using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
			{
				csv.Configuration.RegisterClassMap<WorldCityRecordClassMap>();
				csv.Configuration.Delimiter = ",";
				csv.Configuration.Encoding = Encoding.UTF8;
				csv.Configuration.BadDataFound = null;

				result = await csv.GetRecordsAsync<WorldCityRecord>().ToListAsync();
			}
			return Maybe.Some(result);
		}
	}
}
