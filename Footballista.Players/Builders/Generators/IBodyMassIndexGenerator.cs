using Footballista.BuildingBlocks.Domain.Game;
using Footballista.BuildingBlocks.Domain.Percentiles;
using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Players.Growths;
using Footballista.Players.Persons;
using Itenso.TimePeriod;
using System;
using System.Linq;

namespace Footballista.Players.Builders.Generators
{
	public interface IBodyMassIndexGenerator
	{
		BodyMassIndex Generate(Country country, Gender playerGender, Percentile percentile, Date dob);
	}
	public class BodyMassIndexGenerator : IBodyMassIndexGenerator
	{
		private readonly IGame _game;
		private readonly IPercentileGrowthSetRepository _percentileGrowthSetRepository;

		public BodyMassIndexGenerator(
			IGame game,
			IPercentileGrowthSetRepository percentileGrowthSetRepository
		)
		{
			_game = game;
			_percentileGrowthSetRepository = percentileGrowthSetRepository;
		}

		public BodyMassIndex Generate(Country country, Gender playerGender, Percentile percentile, Date dob)
		{
			// retrieve game current date
			DateTime gameDate = _game.CurrentDate;

			// get player age
			Age playerAge = Age.FromDate(dob, gameDate);
			playerAge = Age.FromYears(Math.Round(playerAge.Years, 0)); // round the value to be able to filter on it.

			AbstractPercentileGrowthSet growthset = _percentileGrowthSetRepository.GetPercentileGrowthSet(playerGender);

			PercentileGrowth percentileGrowth = growthset.GetForPercentile(percentile);

			StatureForAge stature = percentileGrowth.StaturesForAges.FirstOrDefault(sfa => sfa.Age.Equals(playerAge));
			WeightForAge weightForAge = percentileGrowth.WeightForAges.FirstOrDefault(wfa => wfa.Age.Equals(playerAge));

			return new BodyMassIndex(stature.Stature, weightForAge.Mass);
		}
	}
}
