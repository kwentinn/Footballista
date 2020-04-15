using Footballista.Players.Persons;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;

namespace Footballista.Players.Infrastracture
{
	public class StatureGrowthRecordLoader : AbstractGrowthRecordsLoader, IStatureGrowthRecordLoader
	{
		private readonly IHostEnvironment _hostEnvironment;
		private readonly string _folderPath = @"\..\data\growth-charts\stature\";
		private readonly string _filePathForMale = @"Stature-for-age-Male-2-to-20-years.csv";
		private readonly string _filePathForFemale = @"Stature-for-age-Female-2-to-20-years.csv";

		public StatureGrowthRecordLoader(IHostEnvironment hostEnvironment)
		{
			_hostEnvironment = hostEnvironment;
		}

		protected override string GetCompletePath(Gender gender) => 
			gender switch
			{
				Gender.Male => GetFullPath(_filePathForMale),
				Gender.Female => GetFullPath(_filePathForFemale),
				_ => throw new ArgumentException(nameof(gender)),
			};
		private string GetFullPath(string path) =>
			Path.GetFullPath(string.Concat(_hostEnvironment.ContentRootPath, _folderPath, path));
	}
}

