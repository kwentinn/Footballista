using Footballista.Wasm.Shared.Data.Competitions;
using MediatR;
using System.Collections.Generic;

namespace Footballista.Wasm.Server.Queries
{
	public class GetCompetitionRanking : IRequest<List<CompetitionRanking>>
	{
	}
}
