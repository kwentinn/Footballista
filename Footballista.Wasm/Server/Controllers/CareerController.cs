using Footballista.Cqrs;
using Footballista.Cqrs.Commands.CreateCareer;
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
		private readonly IMediatorWrapper _mediator;

		public CareerController(ICareerService careerService, IMediatorWrapper mediator)
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
            CreateCareerCommand cmd = new CreateCareerCommandBuilder(career.Name)
				.WithClubId(new Game.Domain.Clubs.ClubId(career.Club.Id))
				.WithCompetitionId(new Game.Domain.Careers.CompetitionId(career.CurrentCompetition.Id))
				.WithDate(career.CurrentDate.ToDate())
				.WithSeasonId(new Game.Domain.Careers.SeasonId(career.CurrentSeason.Id))
				.WithManager(new Game.Domain.Careers.Manager(career.Manager.Firstname, career.Manager.Lastname))
				.Build();

			await _mediator.DispatchAsync(cmd);

			return Ok();
		}
	}
}
