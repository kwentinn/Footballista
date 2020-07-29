using Footballista.Wasm.Server.Services;
using Footballista.Wasm.Shared.Data.Careers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Footballista.Wasm.Server.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class CareerController : ControllerBase
	{
		private readonly ICareerService _careerService;

		public CareerController(ICareerService careerService)
		{
			_careerService = careerService;
		}

		[HttpGet]
		[Route("all")]
		public List<string> GetAll()
		{
			return _careerService.GetAll();
		}

		[HttpGet]
		[Route("load")]
		public async Task<IActionResult> LoadCareer(Guid careerGuid)
		{
			Career career = await _careerService.LoadCareerAsync(careerGuid);
			return Ok(career);
		}
	}
}
