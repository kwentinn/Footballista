using Footballista.Cqrs.Base.Queries;
using System.Collections.Generic;
using Footballista.Wasm.Shared.Data.Clubs;
using System.Threading.Tasks;

namespace Footballista.Cqrs.Queries.GetClubListForCompetition
{
    public class GetClubsForCompetitionQueryHandler : QueryHandler<GetClubsForCompetitionQuery, List<Club>>
    {
        public override Task<List<Club>> Handle(GetClubsForCompetitionQuery query)
        {
            throw new System.NotImplementedException();
        }
    }
}
