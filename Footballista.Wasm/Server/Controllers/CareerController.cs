using Footballista.Wasm.Client.Dto.Models.Careers;
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

		[HttpPost]
		[Route("create")]
		public async Task<IActionResult> CreateCareer([FromBody]CareerDto career)
		{
			var r = await Task.FromResult(career);
			return Ok(r);

			//await _careerService.CreateCareerAsync
			//(
			//	career.Name,
			//	career.CurrentCompetition.Id,
			//);
		}
	}
}
