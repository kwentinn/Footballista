using Footballista.Wasm.Server.Services;
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
		private readonly IRankingService _rankingService;

		public RankingController(IRankingService rankingService)
		{
			_rankingService = rankingService;
		}

		[HttpGet]
		public async Task<List<CompetitionRanking>> GetGeneratedPlayersAsync()
		{
			return await _rankingService.GetCompetitionRankingsAsync();
		}
	}
}
