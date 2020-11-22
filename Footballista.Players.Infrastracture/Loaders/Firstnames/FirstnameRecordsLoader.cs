using CsvHelper;
using Footballista.BuildingBlocks.Domain;
using Footballista.Players.Infrastracture.Loaders.Firstnames.ClassMaps;
using Footballista.Players.Infrastracture.Loaders.Firstnames.Records;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footballista.Players.Infrastracture.Loaders.Firstnames
{
	public class FirstnameRecordsLoader : IFirstnameRecordsLoader
	{
		private readonly string _folderPath = @"..\data\firstnames";
		private readonly string _filename = "firstnames-2014.csv";

		private const string CSV_DELIMITER = ";";
		private readonly Encoding CSV_ENCODING = Encoding.UTF8;
		private readonly CultureInfo CSV_READER_CULTURE = CultureInfo.InvariantCulture;

		private readonly IDataPathHelper _dataPathHelper;

		public FirstnameRecordsLoader(IDataPathHelper dataPathHelper)
		{
			_dataPathHelper = dataPathHelper;
		}

		public Maybe<List<FirstnameRecord>> GetRecords()
		{
			List<FirstnameRecord> result;

			string fullPath = _dataPathHelper.GetFullPath(_folderPath, _filename);

			using (var reader = new StreamReader(fullPath))
			using (var csv = new CsvReader(reader, CSV_READER_CULTURE))
			{
				csv.Configuration.RegisterClassMap<FirstnameRecordClassMap>();
				csv.Configuration.Delimiter = CSV_DELIMITER;
				csv.Configuration.Encoding = CSV_ENCODING;

				result = csv.GetRecords<FirstnameRecord>().ToList();
			}

			return Maybe.Some(result);
		}
		public async Task<Maybe<List<FirstnameRecord>>> GetRecordsAsync()
		{
			List<FirstnameRecord> result;

			string fullPath = _dataPathHelper.GetFullPath(_folderPath, _filename);

			using (var reader = new StreamReader(fullPath))
			using (var csv = new CsvReader(reader, CSV_READER_CULTURE))
			{
				csv.Configuration.RegisterClassMap<FirstnameRecordClassMap>();
				csv.Configuration.Delimiter = CSV_DELIMITER;
				csv.Configuration.Encoding = CSV_ENCODING;

				result = await csv.GetRecordsAsync<FirstnameRecord>().ToListAsync();
			}

			return Maybe.Some(result);
		}
	}
}
