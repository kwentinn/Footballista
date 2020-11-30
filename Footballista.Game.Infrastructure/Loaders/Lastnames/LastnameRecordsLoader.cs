using CsvHelper;
using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Players.Infrastracture.Loaders.Lastnames.Records;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footballista.Players.Infrastracture.Loaders.Lastnames
{
	public class LastnameRecordsLoader : ILastnameRecordsLoader
	{
		private const string CSV_DELIMITER = ";";
		private readonly string _folderPath = @"..\data\lastnames";
		private readonly IDataPathHelper _dataPathHelper;

		private string Filename(Country country) => $"{country.RegionInfo.TwoLetterISORegionName}.txt";


		public LastnameRecordsLoader(IDataPathHelper dataPathHelper)
		{
			_dataPathHelper = dataPathHelper;
		}

		public List<LastnameRecord> GetRecords(Country country)
		{
			List<LastnameRecord> result;

			var path = _dataPathHelper.GetFullPath(_folderPath, Filename(country));

			using (var reader = new StreamReader(path))
			using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
			{
				csv.Configuration.Delimiter = CSV_DELIMITER;
				csv.Configuration.Encoding = Encoding.UTF8;
				csv.Configuration.HasHeaderRecord = false;
				csv.Configuration.BadDataFound = null;

				result = csv.GetRecords<LastnameRecord>().ToList();
			}
			return result;
		}

		public async Task<List<LastnameRecord>> GetRecordsAsync(Country country)
		{
			List<LastnameRecord> result;

			var path = _dataPathHelper.GetFullPath(_folderPath, Filename(country));

			using (var reader = new StreamReader(path))
			using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
			{
				csv.Configuration.Delimiter = CSV_DELIMITER;
				csv.Configuration.Encoding = Encoding.UTF8;
				csv.Configuration.HasHeaderRecord = false;
				csv.Configuration.BadDataFound = null;

				result = await csv.GetRecordsAsync<LastnameRecord>().ToListAsync();
			}
			return result;
		}
	}
}
