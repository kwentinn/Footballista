using Footballista.Cqrs.Base.Queries;
using Footballista.Wasm.Shared.Data.Competitions;
using System.Collections.Generic;

namespace Footballista.Cqrs.Queries.GetCompetitionRankings
{
    public class GetCompetitionRanking : IQuery<List<CompetitionRanking>>
    {
    }
}
