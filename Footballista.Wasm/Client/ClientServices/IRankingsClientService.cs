﻿using Footballista.Wasm.Shared.Data.Competitions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Footballista.Wasm.Client.ClientServices
{
	public interface IRankingsClientService
	{
		Task<List<CompetitionRanking>> GetRankings();
	}

}
