using Footballista.Cqrs.Base.Queries;
using System.Collections.Generic;
using Footballista.Wasm.Shared.Data.Clubs;
using System.Threading.Tasks;
using Footballista.Game.Domain.Clubs;
using Footballista.Game.Domain.Careers;
using System.Linq;

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
            IEnumerable<Game.Domain.Clubs.Club> domainClubs = await this.clubRepository
                .GetClubsInCompetition(new CompetitionId(query.competitionId));

            return domainClubs
                .Select(dc => new Wasm.Shared.Data.Clubs.Club(dc.Id.Value, dc.Name, dc.Abbreviation))
                .ToList();
        }
    }
}
