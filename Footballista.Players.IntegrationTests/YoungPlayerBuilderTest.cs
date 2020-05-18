using Footballista.Players.Builders;
using Footballista.Players.Builders.Generators;
using Footballista.Players.Builders.Randomisers;
using Footballista.Players.Infrastracture.Generators;
using Footballista.Players.Infrastracture.Loaders;
using Footballista.Players.Infrastracture.Loaders.Cities;
using Footballista.Players.Infrastracture.Loaders.Firstnames;
using Footballista.Players.Infrastracture.Loaders.Growths;
using Footballista.Players.Infrastracture.Loaders.Lastnames;
using Footballista.Players.Infrastracture.Repositories;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.IO;

namespace Footballista.Players.IntegrationTests
{
	[TestClass]
	public class YoungPlayerBuilderTest
	{
		private readonly Game.Domain.Game _game;
		private readonly IntRandomiser _intRandomiser;
		private readonly AgeRandomiser _ageRandomiser;
		private readonly FeatureRatingRandomiser _featureRatingRandomiser;
		private readonly DataPathHelper _dataPathHelper;
		private readonly FirstnameRecordsLoader _firstnameRecordsLoader;
		private readonly LastnameRecordsLoader _lastnameRecordsLoader;
		private readonly ListRandomiser _listRandomiser;
		private readonly FirstnameGenerator _firstnameGenerator;
		private readonly LastnameGenerator _lastnameGenerator;
		private readonly PersonNameGenerator _personNameGenerator;
		private readonly GenderGenerator _genderGenerator;
		private readonly DateOfBirthGenerator _dobGenerator;
		private readonly WorldCitiesLoader _worldCitiesLoader;
		private readonly BirthLocationGenerator _birthLocationGenerator;
		private readonly PercentileGenerator _percentileGenerator;
		private readonly FavouriteFootGenerator _favouriteFootGenerator;
		private readonly PhysicalFeatureSetGenerator _physicalFeatureSetGenerator;
		private readonly StatureGrowthRecordLoader _statureGrLoader;
		private readonly WeightGrowthRecordLoader _weightGrLoader;
		private readonly PercentileGrowthSetRepository _percentileGrRepository;
		private readonly BodyMassIndexGenerator _bmiGenerator;
		private readonly CountriesGenerator _countriesGenerator;
		private readonly GrowthSetGenerator _growthSetGenerator;
		private readonly PlayerPositionGenerator _playerPositionGenerator;
		private readonly Mock<IHostEnvironment> _mockHostingEnv;

		public YoungPlayerBuilderTest()
		{
			//initialise dependencies
			string dataDir = Directory.GetCurrentDirectory() + @"\..\..\..\";


			// arrange: create & setup mocks, create loader with mock
			_mockHostingEnv = new Mock<IHostEnvironment>();
			_mockHostingEnv
				.Setup(env => env.ContentRootPath)
				.Returns(() => dataDir);

			_game = new Game.Domain.Game("test game", DateTime.Parse("2020-01-01"));

			_intRandomiser = new IntRandomiser();
			_ageRandomiser = new AgeRandomiser();
			_featureRatingRandomiser = new FeatureRatingRandomiser();
			_dataPathHelper = new DataPathHelper(_mockHostingEnv.Object);
			_firstnameRecordsLoader = new FirstnameRecordsLoader(_dataPathHelper);
			_lastnameRecordsLoader = new LastnameRecordsLoader(_dataPathHelper);
			_listRandomiser = new ListRandomiser(_intRandomiser);
			_firstnameGenerator = new FirstnameGenerator(_firstnameRecordsLoader, _listRandomiser);
			_lastnameGenerator = new LastnameGenerator(_lastnameRecordsLoader, _listRandomiser);
			_personNameGenerator = new PersonNameGenerator(_firstnameGenerator, _lastnameGenerator);
			_genderGenerator = new GenderGenerator(_intRandomiser);
			_dobGenerator = new DateOfBirthGenerator(_game, _ageRandomiser);
			_worldCitiesLoader = new WorldCitiesLoader(_dataPathHelper);
			_birthLocationGenerator = new BirthLocationGenerator(_worldCitiesLoader, _listRandomiser);
			_percentileGenerator = new PercentileGenerator(_intRandomiser);
			_favouriteFootGenerator = new FavouriteFootGenerator(_percentileGenerator);
			_physicalFeatureSetGenerator = new PhysicalFeatureSetGenerator(_featureRatingRandomiser);
			_statureGrLoader = new StatureGrowthRecordLoader(_dataPathHelper);
			_weightGrLoader = new WeightGrowthRecordLoader(_dataPathHelper);
			_percentileGrRepository = new PercentileGrowthSetRepository(_statureGrLoader, _weightGrLoader);
			_bmiGenerator = new BodyMassIndexGenerator(_game, _percentileGrRepository);
			_countriesGenerator = new CountriesGenerator(_listRandomiser, _intRandomiser);
			_growthSetGenerator = new GrowthSetGenerator(_percentileGrRepository, _listRandomiser);
			_playerPositionGenerator = new PlayerPositionGenerator(_percentileGenerator);
		}

		[TestMethod]
		public void Build()
		{
			var builder = new YoungPlayerBuilder(
				nameGenerator: _personNameGenerator,
				genderGenerator: _genderGenerator,
				dobGenerator: _dobGenerator,
				birthLocationGenerator: _birthLocationGenerator,
				favouriteFootGenerator: _favouriteFootGenerator,
				physicalFeatureSetGenerator: _physicalFeatureSetGenerator,
				bmiGenerator: _bmiGenerator,
				countriesGenerator: _countriesGenerator,
				growthSetGenerator: _growthSetGenerator,
				percentileGenerator: _percentileGenerator,
				playerPositionGenerator: _playerPositionGenerator,
				game: _game
			);

			var player = builder.Build();

			Assert.IsNotNull(player);
		}
	}
}
