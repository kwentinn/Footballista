using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Players.Builders.Generators;
using Footballista.Players.Features;
using Footballista.Players.Persons;
using Footballista.Players.PlayerNames;
using Footballista.Players.Positions;
using Itenso.TimePeriod;
using UnitsNet;

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
		private readonly IStatureGenerator _statureGenerator;
		private readonly IWeightGenerator _weightGenerator;
		private readonly ICountriesGenerator _countriesGenerator;

		public YoungPlayerBuilder
		(
			INameGenerator nameGenerator,
			IGenderGenerator genderGenerator,
			IDateOfBirthGenerator dobGenerator,
			IBirthLocationGenerator birthLocationGenerator,
			IFavouriteFootGenerator favouriteFootGenerator,
			IPhysicalFeatureSetGenerator physicalFeatureSetGenerator,
			IStatureGenerator statureGenerator,
			IWeightGenerator weightGenerator,
			ICountriesGenerator countriesGenerator
		)
		{
			_nameGenerator = nameGenerator;
			_genderGenerator = genderGenerator;
			_dobGenerator = dobGenerator;
			_birthLocationGenerator = birthLocationGenerator;
			_favouriteFootGenerator = favouriteFootGenerator;
			_physicalFeatureSetGenerator = physicalFeatureSetGenerator;
			_statureGenerator = statureGenerator;
			_weightGenerator = weightGenerator;
			_countriesGenerator = countriesGenerator;
		}

		public Player Build(Country country = null, PlayerPosition playerPosition = null)
		{
			Name playerName = _nameGenerator.Generate(country);
			Gender playerGender = _genderGenerator.Generate();
			Date dob = _dobGenerator.Generate();
			Location birthLocation = _birthLocationGenerator.Generate(country);
			Foot playerFoot = _favouriteFootGenerator.Generate();
			PhysicalFeatureSet playerFeatureSet = _physicalFeatureSetGenerator.Generate();
			Length playerStature = _statureGenerator.Generate(country);
			Mass playerWeight = _weightGenerator.Generate(country);
			Country[] countries = _countriesGenerator.Generate();

			// first name & last name => according to the player's country
			return Player.CreatePlayer
			(
				playerName.Firstname, 
				playerName.Lastname, 
				playerGender, 
				dob,
				birthLocation,
				playerFoot,
				playerStature,
				playerWeight,
				playerFeatureSet,
				countries
			);
		}
	}
}
