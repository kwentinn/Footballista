using Footballista.Cqrs.Commands;
using Footballista.Wasm.Client.Dto.Models.Careers;
using Footballista.Wasm.Server.Services;
using Footballista.Wasm.Shared.Data.Careers;
using MediatR;
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
		private readonly IMediator _mediator;

		public CareerController(ICareerService careerService, IMediator mediator)
		{
			_careerService = careerService;
			_mediator = mediator;
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
			await _mediator.Send(new CreateCareerCommand());

			//var r = await Task.FromResult(career);
			return Ok();

			//await _careerService.CreateCareerAsync
			//(
			//	career.Name,
			//	career.CurrentCompetition.Id,
			//);
		}
	}
}
