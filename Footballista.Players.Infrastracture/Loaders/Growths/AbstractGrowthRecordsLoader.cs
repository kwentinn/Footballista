using CsvHelper;
using Footballista.Players.Infrastracture.Loaders.Growths.Records;
using Footballista.Players.Persons;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Footballista.Players.Infrastracture.Loaders.Growths
{
	public abstract class AbstractGrowthRecordsLoader
	{
		private readonly IDataPathHelper _dataPathHelper;

		private readonly string _folderPath = @"\..\data\growth-charts\";

		public abstract string FilePathForMale { get; }
		public abstract string FilePathForFemale { get; }

		protected AbstractGrowthRecordsLoader(IDataPathHelper dataPathHelper)
		{
			_dataPathHelper = dataPathHelper;
		}

		public List<GrowthRecord> GetRecords(Gender gender)
		{
			List<GrowthRecord> result;
			using (var reader = new StreamReader(GetCompletePath(gender)))
			using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
			{
				result = csv.GetRecords<GrowthRecord>().ToList();
			}
			return result;
		}
		private string GetCompletePath(Gender gender) =>
			gender switch
			{
				Gender.Male => _dataPathHelper.GetFullPath(_folderPath, FilePathForMale),
				Gender.Female => _dataPathHelper.GetFullPath(_folderPath, FilePathForFemale),
				_ => throw new ArgumentException("Incorrect gender value", nameof(gender)),
			};
	}
}

