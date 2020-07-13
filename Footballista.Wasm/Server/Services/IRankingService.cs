using Footballista.Wasm.Shared.Data.Competitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Footballista.Wasm.Server.Services
{
	public interface IRankingService
	{
		Task<List<CompetitionRanking>> GetCompetitionRankingsAsync();
	}
}
