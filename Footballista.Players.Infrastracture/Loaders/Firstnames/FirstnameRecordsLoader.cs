using CsvHelper;
using Footballista.Players.Infrastracture.Loaders.Firstnames.ClassMaps;
using Footballista.Players.Infrastracture.Loaders.Firstnames.Records;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Footballista.Players.Infrastracture.Loaders.Firstnames
{
	public class FirstnameRecordsLoader : IFirstnameRecordsLoader
	{
		private readonly string _folderPath = @"..\data\firstnames";
		private readonly string _filename = "firstnames-2014.csv";
		
		private readonly IDataPathHelper _dataPathHelper;

		public FirstnameRecordsLoader(IDataPathHelper dataPathHelper)
		{
			_dataPathHelper = dataPathHelper;
		}

		public List<FirstnameRecord> GetRecords()
		{
			List<FirstnameRecord> result;

			string fullPath = _dataPathHelper.GetFullPath(_folderPath, _filename);

			using (var reader = new StreamReader(fullPath))
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
