using Footballista.Cqrs.Base.Queries;
using System.Collections.Generic;
using Footballista.Wasm.Shared.Data.Clubs;

namespace Footballista.Cqrs.Queries.GetClubListForCompetition
{
    public class GetClubsForCompetitionQuery : IQuery<List<Club>>
    {
        public int competitionId { get; set; }

        public GetClubsForCompetitionQuery(int competitionId)
        {
            this.competitionId = competitionId;
        }
    }
}
