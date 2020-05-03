using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Players;
using Footballista.Players.Builders;
using Footballista.Players.Builders.Generators;
using Footballista.Players.Growths;
using Footballista.Players.Infrastracture.Loaders.Cities;
using Footballista.Players.Infrastracture.Loaders.Firstnames;
using Footballista.Players.Infrastracture.Loaders.Lastnames;
using Footballista.Players.Persons;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Footballista.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class TestController : ControllerBase
	{
		private readonly IPercentileGrowthSetRepository _percentileGrowthSetRepository;
		private readonly IFirstnameRecordsLoader _firstnameRecordsLoader;
		private readonly ILastnameRecordsLoader _lastnameRecordsLoader;
		private readonly IWorldCitiesLoader _worldCitiesLoader;
		private readonly IBirthLocationGenerator _birthLocationGenerator;
		private readonly INameGenerator _nameGenerator;
		private readonly IDateOfBirthGenerator _dateOfBirthGenerator;
		private readonly ICountriesGenerator _countriesGenerator;
		private readonly IGrowthSetGenerator _growthSetGenerator;
		private readonly IPlayerBuilder _playerBuilder;

		public TestController
		(
			IPercentileGrowthSetRepository percentileGrowthSetRepository,
			IFirstnameRecordsLoader firstnameRecordsLoader,
			ILastnameRecordsLoader lastnameRecordsLoader,
			IWorldCitiesLoader worldCitiesLoader,
			IBirthLocationGenerator birthLocationGenerator,
			INameGenerator nameGenerator,
			IDateOfBirthGenerator dateOfBirthGenerator,
			ICountriesGenerator countriesGenerator,
			IGrowthSetGenerator growthSetGenerator,
			IPlayerBuilder playerBuilder
		)
		{
			_percentileGrowthSetRepository = percentileGrowthSetRepository;
			_firstnameRecordsLoader = firstnameRecordsLoader;
			_lastnameRecordsLoader = lastnameRecordsLoader;
			_worldCitiesLoader = worldCitiesLoader;
			_birthLocationGenerator = birthLocationGenerator;
			_nameGenerator = nameGenerator;
			_dateOfBirthGenerator = dateOfBirthGenerator;
			_countriesGenerator = countriesGenerator;
			_growthSetGenerator = growthSetGenerator;
			_playerBuilder = playerBuilder;
		}

		[HttpGet]
		[Route("players-growth")]
		public IActionResult Get()
		{
			FemalePercentileGrowthSet data = _percentileGrowthSetRepository.GetFemalePercentileGrowthSet();
			return Ok();
		}
		[HttpGet]
		[Route("firstnames")]
		public IActionResult GetFirstnames()
		{
			var data = _firstnameRecordsLoader.GetRecords();
			return Ok(data);
		}
		[HttpGet]
		[Route("lastnames")]
		public IActionResult GetLastnames()
		{
			var data = _lastnameRecordsLoader.GetRecords(new Country("gb-nir"));
			return Ok(data);
		}
		[HttpGet]
		[Route("worldcities")]
		public IActionResult GetWorldCities()
		{
			var data = _worldCitiesLoader.GetRecords();
			return Ok();
		}
		[HttpGet]
		[Route("generatebirthlocation")]
		public IActionResult GenerateBirthLocation()
		{
			Location data = _birthLocationGenerator.Generate(new Country("fr"));
			return Ok(data);
		}
		[HttpGet]
		[Route("generatebirthlocation/1000")]
		public IActionResult Generate1000BirthLocation()
		{
			List<Location> list = new List<Location>();
			for (int i = 0; i < 1000; i++)
			{
				list.Add(_birthLocationGenerator.Generate(new Country("fr")));
			}
			return Ok(list);
		}
		[HttpGet]
		[Route("generatename")]
		public IActionResult GenerateName()
		{
			var name = _nameGenerator.Generate(Players.Persons.Gender.Male, Country.France);
			return Ok(name);
		}
		[HttpGet]
		[Route("generatedob")]
		public IActionResult GenerateDoB()
		{
			var dob = _dateOfBirthGenerator.Generate();
			return Ok(dob);
		}
		[HttpGet]
		[Route("generatecountry")]
		public IActionResult GenerateCountries()
		{
			var country = _countriesGenerator.Generate();
			return Ok(country);
		}
		[HttpGet]
		[Route("generategrowth")]
		public IActionResult GenerateGrowth()
		{
			var growthSet = _growthSetGenerator.GeneratePercentileGrowth(Gender.Male);
			return Ok(growthSet);
		}
		[HttpGet]
		[Route("generateplayer")]
		public IActionResult GeneratePlayer()
		{
			var player = _playerBuilder.Build();

			return Ok(new
			{
				Name = $"{player.Firstname.Value} {player.Lastname.Value}",
				Nationalities = string.Join(",", player.Nationalities.Select(n => n.RegionInfo.EnglishName)),
				BirthInfo = new
				{
					City = new
					{
						player.BirthInfo.BirthLocation.City.Name,
						Country = player.BirthInfo.BirthLocation.Country.RegionInfo.EnglishName
					},
					Dob = player.BirthInfo.DateOfBirth.DateTime
				},
				Foot = player.FavouriteFoot.ToString(),
				Bmi = new
				{
					HeightInCentimeters = player.Bmi.Height.Centimeters,
					WeightInKilograms = player.Bmi.Weight.Kilograms
				},
				Gender = player.Gender.ToString()
			});
		}
		[HttpGet]
		[Route("generateplayers")]
		public IActionResult GeneratePlayers()
		{
			var list = new List<Player>();
			var countries = new Country[] { Country.Poland };
			
			for (var i = 0; i < 100; i++)
			{
				list.Add(_playerBuilder.Build(Gender.Male, countries));
			}

			var playersDto = list
				.Select(player => new
				{
					Name = $"{player.Firstname.Value} {player.Lastname.Value}",
					Nationalities = string.Join(",", player.Nationalities.Select(n => n.RegionInfo.EnglishName)),
					BirthInfo = new
					{
						City = new
						{
							player.BirthInfo.BirthLocation.City.Name,
							Country = player.BirthInfo.BirthLocation.Country.RegionInfo.EnglishName
						},
						Dob = player.BirthInfo.DateOfBirth.DateTime
					},
					Foot = player.FavouriteFoot.ToString(),
					Bmi = new
					{
						HeightInCentimeters = Math.Round(player.Bmi.Height.Centimeters, 0),
						WeightInKilograms = Math.Round(player.Bmi.Weight.Kilograms, 0)
					},
					Gender = player.Gender.ToString(),
					Position = player.PlayerPosition.Name
				})
				.ToList();

			return Ok(playersDto);
		}

	}
}
