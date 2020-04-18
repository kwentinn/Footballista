using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Players.Builders.Generators;
using Footballista.Players.Growths;
using Footballista.Players.Infrastracture.Loaders.Cities;
using Footballista.Players.Infrastracture.Loaders.Firstnames;
using Footballista.Players.Infrastracture.Loaders.Lastnames;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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

		public TestController
		(
			IPercentileGrowthSetRepository percentileGrowthSetRepository,
			IFirstnameRecordsLoader firstnameRecordsLoader,
			ILastnameRecordsLoader lastnameRecordsLoader,
			IWorldCitiesLoader worldCitiesLoader,
			IBirthLocationGenerator birthLocationGenerator,
			INameGenerator nameGenerator,
			IDateOfBirthGenerator dateOfBirthGenerator
		)
		{
			_percentileGrowthSetRepository = percentileGrowthSetRepository;
			_firstnameRecordsLoader = firstnameRecordsLoader;
			_lastnameRecordsLoader = lastnameRecordsLoader;
			this._worldCitiesLoader = worldCitiesLoader;
			this._birthLocationGenerator = birthLocationGenerator;
			_nameGenerator = nameGenerator;
			this._dateOfBirthGenerator = dateOfBirthGenerator;
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
			var name = _dateOfBirthGenerator.Generate();
			return Ok(name);
		}
	}
}
