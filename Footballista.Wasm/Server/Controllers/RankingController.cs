using Footballista.Cqrs;
using Footballista.Cqrs.Queries.GetCompetitionRankings;
using Footballista.Wasm.Shared.Data.Competitions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Footballista.Wasm.Server.Controllers
{
    [ApiController]
	[Route("[controller]")]
	public class RankingController : ControllerBase
	{
		private readonly IMediatorWrapper _mediator;

		public RankingController(IMediatorWrapper mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<List<CompetitionRanking>> Get()
		{
			return await _mediator.GetResultAsync(new GetCompetitionRanking());
		}
	}
}
