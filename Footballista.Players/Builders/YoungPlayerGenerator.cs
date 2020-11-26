using Footballista.BuildingBlocks.Domain.Game;
using Footballista.BuildingBlocks.Domain.Percentiles;
using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Players.Builders.Generators;
using Footballista.Players.Builders.Randomisers;
using Footballista.Players.Features;
using Footballista.Players.Persons;
using Footballista.Players.Physique;
using Footballista.Players.PlayerNames;
using Footballista.Players.Positions;
using Itenso.TimePeriod;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Footballista.Players.Builders
{
	public class YoungPlayerGenerator : IPlayerGenerator
	{
		private readonly IPersonNameGenerator _nameGenerator;
		private readonly IGenderGenerator _genderGenerator;
		private readonly IDateOfBirthGenerator _dobGenerator;
		private readonly IBirthLocationGenerator _birthLocationGenerator;
		private readonly IFavouriteFootGenerator _favouriteFootGenerator;
		private readonly IBodyMassIndexGenerator _bmiGenerator;
		private readonly ICountriesGenerator _countriesGenerator;
		private readonly IGrowthSetGenerator _growthSetGenerator;
		private readonly IPercentileGenerator _percentileGenerator;
		private readonly IPlayerPositionGenerator _playerPositionGenerator;
		private readonly IGame _game;
        private readonly IRandomiser<Rating> randomiser;

        public YoungPlayerGenerator
		(
			IPersonNameGenerator nameGenerator,
			IGenderGenerator genderGenerator,
			IDateOfBirthGenerator dobGenerator,
			IBirthLocationGenerator birthLocationGenerator,
			IFavouriteFootGenerator favouriteFootGenerator,
			IBodyMassIndexGenerator bmiGenerator,
			ICountriesGenerator countriesGenerator,
			IGrowthSetGenerator growthSetGenerator,
			IPercentileGenerator percentileGenerator,
			IPlayerPositionGenerator playerPositionGenerator,
			IGame game,
			IRandomiser<Rating> randomiser
		)
		{
			_nameGenerator = nameGenerator;
			_genderGenerator = genderGenerator;
			_dobGenerator = dobGenerator;
			_birthLocationGenerator = birthLocationGenerator;
			_favouriteFootGenerator = favouriteFootGenerator;
			_bmiGenerator = bmiGenerator;
			_countriesGenerator = countriesGenerator;
			_growthSetGenerator = growthSetGenerator;
			_percentileGenerator = percentileGenerator;
			_playerPositionGenerator = playerPositionGenerator;
			_game = game;
            this.randomiser = randomiser;
        }

		public Player Generate(Gender? playerGender = null, Country[] countries = null, PlayerPosition playerPosition = null)
		{
			if (playerGender == null) playerGender = _genderGenerator.Generate();

			if (countries == null)
			{
				countries = _countriesGenerator.Generate().Value;
			}

			PersonName playerName = _nameGenerator.Generate(playerGender.Value, countries.FirstOrDefault());
			Date dob = _dobGenerator.Generate();

			PersonAge playerAge = PersonAge.FromDate(dob, _game.CurrentDate);

			Location birthLocation = _birthLocationGenerator.Generate(countries.FirstOrDefault());
			Foot playerFoot = _favouriteFootGenerator.Generate();
			Percentile percentile = _percentileGenerator.Generate();
			BodyMassIndex bmi = _bmiGenerator.Generate(countries.FirstOrDefault(), playerGender.Value, percentile, dob);
			PlayerPosition position = _playerPositionGenerator.Generate();
			
			PhysicalFeatureSet playerFeatureSet = new PlayerFeatureGenerator(randomiser)
				.ForPosition(position)
				.ForBmi(bmi)
				.ForCountry(countries.FirstOrDefault())
				.ForPersonAge(playerAge)
				.Generate();

			// first name & last name => according to the player's country
			return new PlayerBuilder()
				.WithName(playerName)
				.WithGender(playerGender.Value)
				.WithBirthInfo(new BirthInfo(dob, birthLocation))
				.WithFoot(playerFoot)
				.WithPercentile(percentile)
				.WithBodyMassIndex(bmi)
				.WithPlayerPosition(position)
				.WithFeatureSet(playerFeatureSet)
				.WithCountries(countries)
				.Build();
		}

		public Player[] GenerateMany(int nbOfPlayers, Gender? playerGender = null, Country[] countries = null, PlayerPosition playerPosition = null)
		{
			var list = new List<Player>();
			for (int i = 0; i < nbOfPlayers; i++)
			{
				list.Add(Generate(playerGender, countries, playerPosition));
			}
			return list.ToArray();
		}
		public Player[] GenerateManyParallel(int nbOfPlayers, Gender? playerGender = null, Country[] countries = null, PlayerPosition playerPosition = null)
		{
			var items = new BlockingCollection<Player>();
			Parallel.For(0, nbOfPlayers, (i) =>
			{
				items.Add(Generate(Gender.Male));
			});
			items.CompleteAdding();
			return items.ToArray();
		}

		public async Task<Player[]> GenerateManyAsync(int nbOfPlayers, Gender? playerGender = null, Country[] countries = null, PlayerPosition playerPosition = null)
		{
			List<Task<Player>> tasks = new List<Task<Player>>();
			for (int i = 0; i < nbOfPlayers; i++)
			{
				tasks.Add(GenerateAsync(playerGender, countries, playerPosition));
			}
			return await Task.WhenAll(tasks);
		}
		public async Task<Player> GenerateAsync(Gender? playerGender = null, Country[] countries = null, PlayerPosition playerPosition = null)
		{
			if (playerGender == null) playerGender = _genderGenerator.Generate();

			if (countries == null)
			{
				countries = _countriesGenerator.Generate().Value;
			}

			PersonName playerName = await _nameGenerator.GenerateAsync(
				playerGender.Value,
				countries.FirstOrDefault());

			Date dob = _dobGenerator.Generate();

			PersonAge playerAge = PersonAge.FromDate(dob, _game.CurrentDate);

			Location birthLocation = await _birthLocationGenerator.GenerateAsync(countries.FirstOrDefault());
			Foot playerFoot = _favouriteFootGenerator.Generate();
			Percentile percentile = _percentileGenerator.Generate();
			BodyMassIndex bmi = _bmiGenerator.Generate(countries.FirstOrDefault(), playerGender.Value, percentile, dob);
			PlayerPosition position = _playerPositionGenerator.Generate();
			
			PhysicalFeatureSet playerFeatureSet = new PlayerFeatureGenerator(randomiser)
				.ForPosition(position)
				.ForBmi(bmi)
				.ForCountry(countries.FirstOrDefault())
				.ForPersonAge(playerAge)
				.Generate();

			// first name & last name => according to the player's country
			return new PlayerBuilder()
				.WithName(playerName)
				.WithGender(playerGender.Value)
				.WithBirthInfo(new BirthInfo(dob, birthLocation))
				.WithFoot(playerFoot)
				.WithPercentile(percentile)
				.WithBodyMassIndex(bmi)
				.WithPlayerPosition(position)
				.WithFeatureSet(playerFeatureSet)
				.WithCountries(countries)
				.Build();
		}
	}
}
