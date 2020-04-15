using Footballista.Players.Growths;
using Microsoft.AspNetCore.Mvc;

namespace Footballista.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class TestController : ControllerBase
	{
		private readonly IPercentileGrowthSetRepository _percentileGrowthSetRepository;

		public TestController(IPercentileGrowthSetRepository percentileGrowthSetRepository)
		{
			_percentileGrowthSetRepository = percentileGrowthSetRepository;
		}

		[HttpGet]
		public IActionResult Get()
		{
			FemalePercentileGrowthSet data = _percentileGrowthSetRepository.GetFemalePercentileGrowthSet();
			return Ok();
		}
	}
}
