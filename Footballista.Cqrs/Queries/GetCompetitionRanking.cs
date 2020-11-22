using Footballista.Cqrs.BuildingBlocks.Queries;
using Footballista.Wasm.Shared.Data.Competitions;
using System.Collections.Generic;

namespace Footballista.Cqrs.Queries
{
	public class GetCompetitionRanking : IQuery<List<CompetitionRanking>>
	{
	}
}
