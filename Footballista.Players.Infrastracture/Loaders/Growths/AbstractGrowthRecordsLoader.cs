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
		protected readonly IHostEnvironment _hostEnvironment;

		protected string ContentRootPath => _hostEnvironment.ContentRootPath;

		private readonly string _folderPath = @"\..\data\growth-charts\";

		public abstract string FilePathForMale { get; }
		public abstract string FilePathForFemale { get; }

		protected AbstractGrowthRecordsLoader(IHostEnvironment hostEnvironment)
		{
			_hostEnvironment = hostEnvironment ?? throw new ArgumentNullException(nameof(hostEnvironment));
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
				Gender.Male => GetFullPath(FilePathForMale),
				Gender.Female => GetFullPath(FilePathForFemale),
				_ => throw new ArgumentException("Incorrect gender value", nameof(gender)),
			};
		private string GetFullPath(string path) =>
			Path.GetFullPath(string.Concat
			(
				ContentRootPath,
				ContentRootPath.EndsWith("\\") ? "" : "\\",
				_folderPath,
				path
			));
	}
}

