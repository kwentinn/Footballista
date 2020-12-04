using Footballista.Cqrs.Base.Queries;
using Footballista.Game.Domain.Clubs;
using Footballista.Game.Domain.Competitions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Footballista.Cqrs.Queries.GetClubListForCompetition
{
    public class GetClubsForCompetitionQueryHandler : QueryHandler<GetClubsForCompetitionQuery, List<Wasm.Shared.Data.Clubs.Club>>
    {
        private readonly IClubRepository clubRepository;

        public GetClubsForCompetitionQueryHandler(IClubRepository clubRepository)
        {
            this.clubRepository = clubRepository;
        }
        public async override Task<List<Wasm.Shared.Data.Clubs.Club>> Handle(GetClubsForCompetitionQuery query)
        {
            IEnumerable<Club> domainClubs = await this.clubRepository
                .GetClubsInCompetition(new CompetitionId(query.competitionId));

            return domainClubs
                .Select(dc => new Wasm.Shared.Data.Clubs.Club(dc.Id.Value, dc.ClubName.Name, dc.ClubName.Abbreviation))
                .ToList();
        }
    }
}
