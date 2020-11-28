using Footballista.BuildingBlocks.Domain.Game;
using Footballista.Players.Builders;
using Footballista.Players.Builders.Generators;
using Footballista.Players.Builders.Randomisers;
using Footballista.Players.Domain.Features;
using Footballista.Players.Infrastracture.Generators;

namespace Footballista.Players.IntegrationTests.PlayerGenerators.Builders
{
	internal class YoungPlayerGeneratorBuilder
	{
		private FirstnameGenerator _firstnameGenerator;
		private LastnameGenerator _lastnameGenerator;
		private PersonNameGenerator _personNameGenerator;
		private GenderGenerator _genderGenerator;
		private DateOfBirthGenerator _dobGenerator;
		private BirthLocationGenerator _birthLocationGenerator;
		private PercentileGenerator _percentileGenerator;
		private FavouriteFootGenerator _favouriteFootGenerator;
		private BodyMassIndexGenerator _bmiGenerator;
		private CountriesGenerator _countriesGenerator;
		private PlayerPositionGenerator _playerPositionGenerator;
		private IRandomiser<Rating> _ratingRandomiser;

		private readonly IGame _game;

		public YoungPlayerGeneratorBuilder(IGame game)
		{
			_game = game;
		}

		public YoungPlayerGeneratorBuilder WithNameGenerator(PersonNameGenerator personNameGenerator)
		{
			_personNameGenerator = personNameGenerator;
			return this;
		}
		public YoungPlayerGeneratorBuilder WithGenderGenerator(GenderGenerator genderGenerator)
		{
			_genderGenerator = genderGenerator;
			return this;
		}
		public YoungPlayerGeneratorBuilder WithDobGenerator(DateOfBirthGenerator dobGenerator)
		{

			_dobGenerator = dobGenerator;
			return this;
		}
		public YoungPlayerGeneratorBuilder WithBirthLocationGenerator(BirthLocationGenerator birthLocationGenerator)
		{
			_birthLocationGenerator = birthLocationGenerator;
			return this;
		}
		public YoungPlayerGeneratorBuilder WithFavouriteFootGenerator(FavouriteFootGenerator favouriteFootGenerator)
		{
			_favouriteFootGenerator = favouriteFootGenerator;
			return this;
		}
		public YoungPlayerGeneratorBuilder WithBmiGenerator(BodyMassIndexGenerator bmiGenerator)
		{
			_bmiGenerator = bmiGenerator;
			return this;
		}
		public YoungPlayerGeneratorBuilder WithCountriesGenerator(CountriesGenerator countriesGenerator)
		{
			_countriesGenerator = countriesGenerator;
			return this;
		}
		public YoungPlayerGeneratorBuilder WithPercentileGenerator(PercentileGenerator percentileGenerator)
		{
			_percentileGenerator = percentileGenerator;
			return this;
		}
		public YoungPlayerGeneratorBuilder WithPlayerPositionGenerator(PlayerPositionGenerator playerPositionGenerator)
		{
			_playerPositionGenerator = playerPositionGenerator;
			return this;
		}
		public YoungPlayerGeneratorBuilder WithRatingRandomiser(FeatureRatingRandomiser ratingRandomiser)
		{
			_ratingRandomiser = ratingRandomiser;
			return this;
		}

		public YoungPlayerGenerator Build()
		{
			return new YoungPlayerGenerator(
				nameGenerator: _personNameGenerator,
				genderGenerator: _genderGenerator,
				dobGenerator: _dobGenerator,
				birthLocationGenerator: _birthLocationGenerator,
				favouriteFootGenerator: _favouriteFootGenerator,
				bmiGenerator: _bmiGenerator,
				countriesGenerator: _countriesGenerator,
				percentileGenerator: _percentileGenerator,
				playerPositionGenerator: _playerPositionGenerator,
				game: _game,
				_ratingRandomiser);
		}
	}
}
