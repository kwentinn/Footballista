using Footballista.BuildingBlocks.Domain;
using Footballista.BuildingBlocks.Domain.Percentiles;
using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Players.Builders.Generators;
using Footballista.Players.Features;
using Footballista.Players.Persons;
using Footballista.Players.PlayerNames;
using Footballista.Players.Positions;
using Itenso.TimePeriod;
using System.Linq;

namespace Footballista.Players.Builders
{
	public class YoungPlayerBuilder : IPlayerBuilder
	{
		private readonly INameGenerator _nameGenerator;
		private readonly IGenderGenerator _genderGenerator;
		private readonly IDateOfBirthGenerator _dobGenerator;
		private readonly IBirthLocationGenerator _birthLocationGenerator;
		private readonly IFavouriteFootGenerator _favouriteFootGenerator;
		private readonly IPhysicalFeatureSetGenerator _physicalFeatureSetGenerator;
		private readonly IBodyMassIndexGenerator _bmiGenerator;
		private readonly ICountriesGenerator _countriesGenerator;
		private readonly IGrowthSetGenerator _growthSetGenerator;
		private readonly IPercentileGenerator _percentileGenerator;

		public YoungPlayerBuilder
		(
			INameGenerator nameGenerator,
			IGenderGenerator genderGenerator,
			IDateOfBirthGenerator dobGenerator,
			IBirthLocationGenerator birthLocationGenerator,
			IFavouriteFootGenerator favouriteFootGenerator,
			IPhysicalFeatureSetGenerator physicalFeatureSetGenerator,
			IBodyMassIndexGenerator bmiGenerator,
			ICountriesGenerator countriesGenerator,
			IGrowthSetGenerator growthSetGenerator,
			IPercentileGenerator percentileGenerator
		)
		{
			_nameGenerator = nameGenerator;
			_genderGenerator = genderGenerator;
			_dobGenerator = dobGenerator;
			_birthLocationGenerator = birthLocationGenerator;
			_favouriteFootGenerator = favouriteFootGenerator;
			_physicalFeatureSetGenerator = physicalFeatureSetGenerator;
			_bmiGenerator = bmiGenerator;
			_countriesGenerator = countriesGenerator;
			_growthSetGenerator = growthSetGenerator;
			this._percentileGenerator = percentileGenerator;
		}

		public Player Build(Gender? playerGender = null, Country[] countries = null, PlayerPosition playerPosition = null)
		{
			if (playerGender == null) playerGender = _genderGenerator.Generate();

			if (countries == null)
			{
				countries = _countriesGenerator.Generate().Value;
			}

			Name playerName = _nameGenerator.Generate(playerGender.Value, countries.FirstOrDefault());
			Date dob = _dobGenerator.Generate();
			Location birthLocation = _birthLocationGenerator.Generate(countries.FirstOrDefault());
			Foot playerFoot = _favouriteFootGenerator.Generate();
			PhysicalFeatureSet playerFeatureSet = _physicalFeatureSetGenerator.Generate();
			Percentile percentile = _percentileGenerator.Generate();
			BodyMassIndex bmi = _bmiGenerator.Generate(countries.FirstOrDefault(), playerGender.Value, percentile, dob);

			// first name & last name => according to the player's country
			return Player.CreatePlayer
			(
				playerName.Firstname,
				playerName.Lastname,
				playerGender.Value,
				dob,
				birthLocation,
				playerFoot,
				bmi,
				percentile,
				playerFeatureSet,
				countries
			);
		}
	}
}
