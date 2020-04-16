using CsvHelper;
using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Players.Infrastracture.Loaders.Lastnames.Records;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Footballista.Players.Infrastracture.Loaders.Lastnames
{
	public class LastnameRecordsLoader : ILastnameRecordsLoader
	{
		private readonly IHostEnvironment _hostEnvironment;
		private readonly string _folderPath = @"..\data\lastnames";
		private string Filename(Country country) => $"{country.RegionInfo.TwoLetterISORegionName}.txt";

		private string FullPath(Country country) => Path.GetFullPath(string.Concat
		(
			_hostEnvironment.ContentRootPath,
			_hostEnvironment.ContentRootPath.EndsWith(@"\") ? "" : @"\",
			_folderPath, @"\",
			Filename(country)
		));

		public LastnameRecordsLoader(IHostEnvironment hostEnvironment)
		{
			_hostEnvironment = hostEnvironment;
		}

		public List<LastnameRecord> GetRecords(Country country)
		{
			List<LastnameRecord> result;
			using (var reader = new StreamReader(FullPath(country)))
			using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
			{
				csv.Configuration.Delimiter = ";";
				csv.Configuration.Encoding = Encoding.UTF8;
				csv.Configuration.HasHeaderRecord = false;
				csv.Configuration.BadDataFound = null;

				result = csv.GetRecords<LastnameRecord>().ToList();
			}
			return result;
		}
	}
}
