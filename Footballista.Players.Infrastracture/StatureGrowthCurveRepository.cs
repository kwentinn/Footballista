using CsvHelper;
using CsvHelper.Configuration;
using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.BuildingBlocks.Domain.ValueObjects.Units;
using Footballista.BuildingBlocks.Domain.ValueObjects.Units.Length;
using Footballista.Players.Evolutions;
using Footballista.Players.Persons;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Footballista.Players.Infrastracture
{
	internal sealed class StatureGrowthRecord
	{
		public int Age { get; set; }
		public double ThirdPercentile { get; set; }
		public double FifthPercentile { get; set; }
		public double TenthPercentile { get; set; }
		public double TwentyFifthPercentile { get; set; }
		public double FiftiethPercentile { get; set; }
		public double SeventyFifthPercentile { get; set; }
		public double NinetiethPercentile { get; set; }
		public double NinetyFifthPercentile { get; set; }
		public double NinetySeventhPercentile { get; set; }
	}
	internal sealed class AgeValue
	{
		public int Age { get; }
		public double Value { get; }
		public AgeValue(int age, double value)
		{
			Age = age;
			Value = value;
		}
	}
	public class StatureGrowthCurveRepository : IStatureGrowthCurveRepository
	{
		private readonly string _filePath = @"C:\Users\Quentin\Source\Repos\Footballista\data\growth-charts\stature\Stature-for-age-Male-2-to-20-years.csv";
		public async Task<List<StatureGrowthCurve>> GetAllAsync(SystemOfUnitsType systemOfUnitsType)
		{
			var result = new List<StatureGrowthCurve>();

			var config = new CsvConfiguration(new CultureInfo("fr-FR"));

			using (var reader = new StreamReader(_filePath))
			using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
			{
				List<StatureGrowthRecord> list = csv.GetRecords<StatureGrowthRecord>().ToList();

				result.Add(new StatureGrowthCurve
				(
					new Percentile(3),
					new Country("US"),
					Gender.Male,
					SystemOfUnitsType.SI,
					list.Select(r => new LengthGrowth(r.Age, new Meter(Math.Round(r.ThirdPercentile / 100d, 2))))
						.ToList()
				));
				result.Add(new StatureGrowthCurve
				(
					new Percentile(5),
					new Country("US"),
					Gender.Male,
					SystemOfUnitsType.SI,
					list.Select(r => new LengthGrowth(r.Age, new Meter(Math.Round(r.FifthPercentile / 100d, 2))))
						.ToList()
				));

				result.Add(CreateStatureGrowthCurveFromRecords(3, list.Select(r => new AgeValue(r.Age, r.ThirdPercentile)).ToList()));
				result.Add(CreateStatureGrowthCurveFromRecords(10, list.Select(r => new AgeValue(r.Age, r.TenthPercentile)).ToList()));
				result.Add(CreateStatureGrowthCurveFromRecords(25, list.Select(r => new AgeValue(r.Age, r.TwentyFifthPercentile)).ToList()));
				result.Add(CreateStatureGrowthCurveFromRecords(50, list.Select(r => new AgeValue(r.Age, r.FiftiethPercentile)).ToList()));
				result.Add(CreateStatureGrowthCurveFromRecords(75, list.Select(r => new AgeValue(r.Age, r.SeventyFifthPercentile)).ToList()));
				result.Add(CreateStatureGrowthCurveFromRecords(90, list.Select(r => new AgeValue(r.Age, r.NinetiethPercentile)).ToList()));
				result.Add(CreateStatureGrowthCurveFromRecords(95, list.Select(r => new AgeValue(r.Age, r.NinetyFifthPercentile)).ToList()));
				result.Add(CreateStatureGrowthCurveFromRecords(97, list.Select(r => new AgeValue(r.Age, r.NinetySeventhPercentile)).ToList()));
			}
			return result;
		}

		private StatureGrowthCurve CreateStatureGrowthCurveFromRecords(int percentile, List<AgeValue> list)
		{
			return new StatureGrowthCurve
			(
				new Percentile(percentile),
				new Country("US"),
				Gender.Male,
				SystemOfUnitsType.SI,
				list.Select(r => new LengthGrowth(r.Age, new Meter(Math.Round(r.Value / 100d, 2))))
					.ToList()
			);
		}
	}
}
