using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.BuildingBlocks.Domain.ValueObjects.Units;
using Footballista.BuildingBlocks.Domain.ValueObjects.Units.Length;
using Footballista.BuildingBlocks.ValueObjects.Units.Converters;
using Footballista.Players.Evolutions;
using Footballista.Players.Infrastracture.Records;
using Footballista.Players.Persons;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Footballista.Players.Infrastracture
{
	public class StatureGrowthCurveRepository : IStatureGrowthCurveRepository
	{
		private readonly IStatureGrowthRecordLoader _statureGrothRecordLoader;
		private readonly IConverter<Meter, Foot> _unitConverter;

		public StatureGrowthCurveRepository(IStatureGrowthRecordLoader statureGrothRecordLoader, IConverter<Meter, Foot> unitConverter)
		{
			_statureGrothRecordLoader = statureGrothRecordLoader;
			_unitConverter = unitConverter;
		}

		public List<StatureGrowthCurve> GetAll(SystemOfUnitsType systemOfUnitsType)
		{
			var result = new List<StatureGrowthCurve>();

			List<StatureGrowthRecord> list = _statureGrothRecordLoader.GetRecords(Gender.Male);

			// males
			result.Add(CreateStatureGrowthCurveFromRecords(systemOfUnitsType, 3, Gender.Male, list.Select(r => new AgeValue(r.Age, r.ThirdPercentile)).ToList()));
			result.Add(CreateStatureGrowthCurveFromRecords(systemOfUnitsType, 5, Gender.Male, list.Select(r => new AgeValue(r.Age, r.FifthPercentile)).ToList()));
			result.Add(CreateStatureGrowthCurveFromRecords(systemOfUnitsType, 10, Gender.Male, list.Select(r => new AgeValue(r.Age, r.TenthPercentile)).ToList()));
			result.Add(CreateStatureGrowthCurveFromRecords(systemOfUnitsType, 25, Gender.Male, list.Select(r => new AgeValue(r.Age, r.TwentyFifthPercentile)).ToList()));
			result.Add(CreateStatureGrowthCurveFromRecords(systemOfUnitsType, 50, Gender.Male, list.Select(r => new AgeValue(r.Age, r.FiftiethPercentile)).ToList()));
			result.Add(CreateStatureGrowthCurveFromRecords(systemOfUnitsType, 75, Gender.Male, list.Select(r => new AgeValue(r.Age, r.SeventyFifthPercentile)).ToList()));
			result.Add(CreateStatureGrowthCurveFromRecords(systemOfUnitsType, 90, Gender.Male, list.Select(r => new AgeValue(r.Age, r.NinetiethPercentile)).ToList()));
			result.Add(CreateStatureGrowthCurveFromRecords(systemOfUnitsType, 95, Gender.Male, list.Select(r => new AgeValue(r.Age, r.NinetyFifthPercentile)).ToList()));
			result.Add(CreateStatureGrowthCurveFromRecords(systemOfUnitsType, 97, Gender.Male, list.Select(r => new AgeValue(r.Age, r.NinetySeventhPercentile)).ToList()));
			result.Add(CreateStatureGrowthCurveFromRecords(systemOfUnitsType, 98, Gender.Male, list.Select(r => new AgeValue(r.Age, r.NinetyEigthPercentile)).ToList()));


			// females
			list = _statureGrothRecordLoader.GetRecords(Gender.Female);
			result.Add(CreateStatureGrowthCurveFromRecords(systemOfUnitsType, 3, Gender.Female, list.Select(r => new AgeValue(r.Age, r.ThirdPercentile)).ToList()));
			result.Add(CreateStatureGrowthCurveFromRecords(systemOfUnitsType, 5, Gender.Female, list.Select(r => new AgeValue(r.Age, r.FifthPercentile)).ToList()));
			result.Add(CreateStatureGrowthCurveFromRecords(systemOfUnitsType, 10, Gender.Female, list.Select(r => new AgeValue(r.Age, r.TenthPercentile)).ToList()));
			result.Add(CreateStatureGrowthCurveFromRecords(systemOfUnitsType, 25, Gender.Female, list.Select(r => new AgeValue(r.Age, r.TwentyFifthPercentile)).ToList()));
			result.Add(CreateStatureGrowthCurveFromRecords(systemOfUnitsType, 50, Gender.Female, list.Select(r => new AgeValue(r.Age, r.FiftiethPercentile)).ToList()));
			result.Add(CreateStatureGrowthCurveFromRecords(systemOfUnitsType, 75, Gender.Female, list.Select(r => new AgeValue(r.Age, r.SeventyFifthPercentile)).ToList()));
			result.Add(CreateStatureGrowthCurveFromRecords(systemOfUnitsType, 90, Gender.Female, list.Select(r => new AgeValue(r.Age, r.NinetiethPercentile)).ToList()));
			result.Add(CreateStatureGrowthCurveFromRecords(systemOfUnitsType, 95, Gender.Female, list.Select(r => new AgeValue(r.Age, r.NinetyFifthPercentile)).ToList()));
			result.Add(CreateStatureGrowthCurveFromRecords(systemOfUnitsType, 97, Gender.Female, list.Select(r => new AgeValue(r.Age, r.NinetySeventhPercentile)).ToList()));
			result.Add(CreateStatureGrowthCurveFromRecords(systemOfUnitsType, 98, Gender.Female, list.Select(r => new AgeValue(r.Age, r.NinetyEigthPercentile)).ToList()));

			return result;
		}

		private StatureGrowthCurve CreateStatureGrowthCurveFromRecords(SystemOfUnitsType sout, int percentile, Gender gender, List<AgeValue> list)
		{
			return new StatureGrowthCurve
			(
				new Percentile(percentile),
				new Country("US"),
				gender,
				sout,
				list.Select(r => new LengthGrowth(r.Age, ConvertToUnit(sout, r.Value)))
					.ToList()
			);
		}
		private ILengthUnit ConvertToUnit(SystemOfUnitsType sout, double valueInCm)
		{
			Meter m = new Meter(Math.Round(valueInCm / 100d, 2));
			if (sout == SystemOfUnitsType.Imperial)
			{
				return _unitConverter.Convert(m);
			}
			return m;
		}
	}
}
