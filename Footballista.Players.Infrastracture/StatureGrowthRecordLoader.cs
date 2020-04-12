using CsvHelper;
using Footballista.Players.Infrastracture.Records;
using Footballista.Players.Persons;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Footballista.Players.Infrastracture
{
	public class StatureGrowthRecordLoader : IStatureGrowthRecordLoader
	{
		private readonly IHostEnvironment _hostEnvironment;
		private readonly string _folderPath = @"..\data\growth-charts\stature\";
		private readonly string _filePath = @"Stature-for-age-Male-2-to-20-years.csv";
		private readonly string _filePathForFemale = @"Stature-for-age-Female-2-to-20-years.csv";

		public StatureGrowthRecordLoader(IHostEnvironment hostEnvironment)
		{
			_hostEnvironment = hostEnvironment;
		}

		public List<StatureGrowthRecord> GetRecords(Gender gender)
		{
			List<StatureGrowthRecord> result;
			using (var reader = new StreamReader(GetCompletePath(gender)))
			using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
			{
				result = csv.GetRecords<StatureGrowthRecord>().ToList();
			}
			return result;
		}

		private string GetCompletePath(Gender gender)
		{
			string GetFullPath(string path) => Path.GetFullPath(_hostEnvironment.ContentRootPath + _folderPath + path);

			string path;
			if (gender == Gender.Male)
			{
				path = GetFullPath(_filePath);
				return path;
			}
			path = GetFullPath(_filePathForFemale);
			return path;
		}
	}
}
