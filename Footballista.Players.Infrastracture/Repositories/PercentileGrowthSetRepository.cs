using Footballista.Players.Growths;
using Footballista.Players.Infrastracture.Loaders.Growths;
using Footballista.Players.Infrastracture.Loaders.Growths.Records;
using Footballista.Players.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using UnitsNet;
using UnitsNet.Units;

namespace Footballista.Players.Infrastracture.Repositories
{
	public class PercentileGrowthSetRepository : IPercentileGrowthSetRepository
	{
		private readonly IStatureGrowthRecordLoader _statureGrowthRecordLoader;
		private readonly IWeightGrowthRecordLoader _weightGrowthRecordLoader;

		public PercentileGrowthSetRepository
		(
			IStatureGrowthRecordLoader statureGrowthRecordLoader,
			IWeightGrowthRecordLoader weightGrowthRecordLoader
		)
		{
			_statureGrowthRecordLoader = statureGrowthRecordLoader;
			_weightGrowthRecordLoader = weightGrowthRecordLoader;
		}

		public FemalePercentileGrowthSet GetFemalePercentileGrowthSet() =>
			new FemalePercentileGrowthSet(GetPercentileGrowth(Gender.Female));
		public MalePercentileGrowthSet GetMalePercentileGrowthSet() =>
			new MalePercentileGrowthSet(GetPercentileGrowth(Gender.Male));
		public AbstractPercentileGrowthSet GetPercentileGrowthSet(Gender gender) => gender switch
		{
			Gender.Male => GetMalePercentileGrowthSet(),
			Gender.Female => GetFemalePercentileGrowthSet(),
			_ => throw new ApplicationException("unknown gender")
		};

		private List<PercentileGrowth> GetPercentileGrowth(Gender gender)
		{
			WeightForAge CreateWfA(int age, double massInKg) => new WeightForAge(age, new Mass(massInKg, MassUnit.Kilogram));
			StatureForAge CreateSfA(int age, double heightInCm) => new StatureForAge(age, new Length(heightInCm, LengthUnit.Centimeter));

			// load records
			List<GrowthRecord> statureRecords = _statureGrowthRecordLoader.GetRecords(gender).Value;
			List<GrowthRecord> weightRecords = _weightGrowthRecordLoader.GetRecords(gender).Value;



			List<PercentileGrowth> growths = new List<PercentileGrowth>();

			growths.Add(new PercentileGrowth(
				percentile: 3,
				gender: gender,
				weightsForAges: weightRecords
					.Select(r => CreateWfA(r.Age, r.ThirdPercentile))
					.ToList(),
				staturesForAges: statureRecords
					.Select(r => CreateSfA(r.Age, r.ThirdPercentile)).ToList()
			));
			growths.Add(new PercentileGrowth(
				percentile: 5,
				gender: gender,
				weightsForAges: weightRecords.Select(r => CreateWfA(r.Age, r.FifthPercentile)).ToList(),
				staturesForAges: statureRecords.Select(r => CreateSfA(r.Age, r.FifthPercentile)).ToList()
			));
			growths.Add(new PercentileGrowth(
				percentile: 10,
				gender: gender,
				weightsForAges: weightRecords.Select(r => CreateWfA(r.Age, r.TenthPercentile)).ToList(),
				staturesForAges: statureRecords.Select(r => CreateSfA(r.Age, r.TenthPercentile)).ToList()
			));
			growths.Add(new PercentileGrowth(
				percentile: 25,
				gender: gender,
				weightsForAges: weightRecords.Select(r => CreateWfA(r.Age, r.TwentyFifthPercentile)).ToList(),
				staturesForAges: statureRecords.Select(r => CreateSfA(r.Age, r.TwentyFifthPercentile)).ToList()
			));
			growths.Add(new PercentileGrowth(
				percentile: 50,
				gender: gender,
				weightsForAges: weightRecords.Select(r => CreateWfA(r.Age, r.FiftiethPercentile)).ToList(),
				staturesForAges: statureRecords.Select(r => CreateSfA(r.Age, r.FiftiethPercentile)).ToList()
			));
			growths.Add(new PercentileGrowth(
				percentile: 75,
				gender: gender,
				weightsForAges: weightRecords.Select(r => CreateWfA(r.Age, r.SeventyFifthPercentile)).ToList(),
				staturesForAges: statureRecords.Select(r => CreateSfA(r.Age, r.SeventyFifthPercentile)).ToList()
			));
			growths.Add(new PercentileGrowth(
				percentile: 90,
				gender: gender,
				weightsForAges: weightRecords.Select(r => CreateWfA(r.Age, r.NinetiethPercentile)).ToList(),
				staturesForAges: statureRecords.Select(r => CreateSfA(r.Age, r.NinetiethPercentile)).ToList()
			));
			growths.Add(new PercentileGrowth(
				percentile: 95,
				gender: gender,
				weightsForAges: weightRecords.Select(r => CreateWfA(r.Age, r.NinetyFifthPercentile)).ToList(),
				staturesForAges: statureRecords.Select(r => CreateSfA(r.Age, r.NinetyFifthPercentile)).ToList()
			));
			growths.Add(new PercentileGrowth(
				percentile: 97,
				gender: gender,
				weightsForAges: weightRecords.Select(r => CreateWfA(r.Age, r.NinetySeventhPercentile)).ToList(),
				staturesForAges: statureRecords.Select(r => CreateSfA(r.Age, r.NinetySeventhPercentile)).ToList()
			));
			growths.Add(new PercentileGrowth(
				percentile: 98,
				gender: gender,
				weightsForAges: weightRecords.Select(r => CreateWfA(r.Age, r.NinetyEigthPercentile)).ToList(),
				staturesForAges: statureRecords.Select(r => CreateSfA(r.Age, r.NinetyEigthPercentile)).ToList()
			));

			return growths;
		}
	}
}
