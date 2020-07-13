using Footballista.Wasm.Server.Queries;
using Footballista.Wasm.Shared.Data.Competitions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Footballista.Wasm.Server.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class RankingController : ControllerBase
	{
		private readonly IMediator _mediator;

		public RankingController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<List<CompetitionRanking>> Get()
		{
			return await _mediator.Send(new GetCompetitionRanking());
		}
	}
}
