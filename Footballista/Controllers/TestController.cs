using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Players.Growths;
using Footballista.Players.Infrastracture.Loaders.Cities;
using Footballista.Players.Infrastracture.Loaders.Firstnames;
using Footballista.Players.Infrastracture.Loaders.Lastnames;
using Microsoft.AspNetCore.Mvc;

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

		public TestController
		(
			IPercentileGrowthSetRepository percentileGrowthSetRepository,
			IFirstnameRecordsLoader firstnameRecordsLoader,
			ILastnameRecordsLoader lastnameRecordsLoader,
			IWorldCitiesLoader worldCitiesLoader
		)
		{
			_percentileGrowthSetRepository = percentileGrowthSetRepository;
			_firstnameRecordsLoader = firstnameRecordsLoader;
			_lastnameRecordsLoader = lastnameRecordsLoader;
			this._worldCitiesLoader = worldCitiesLoader;
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
	}
}
