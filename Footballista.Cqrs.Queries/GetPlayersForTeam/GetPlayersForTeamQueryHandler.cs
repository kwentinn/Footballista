using Footballista.Cqrs.Base.Queries;
using Footballista.Game.Domain;
using Footballista.Game.Domain.Careers;
using System.Collections.Generic;
using System.Threading.Tasks;
using Footballista.Wasm.Shared;
using SharedPlayers = Footballista.Wasm.Shared.Data.Players;
using Domain = Footballista.Game.Domain.Players;
using System.Linq;

namespace Footballista.Cqrs.Queries.GetPlayersForTeam
{
    public sealed class GetPlayersForTeamQueryHandler : QueryHandler<GetPlayersForTeamQuery, IEnumerable<SharedPlayers.Player>>
    {
        private readonly ICareerRepository careerRepository;
        private readonly IMapper<Domain.Player, SharedPlayers.Player> mapper;

        public GetPlayersForTeamQueryHandler(ICareerRepository careerRepository, IMapper<Domain.Player, SharedPlayers.Player> mapper)
        {
            this.careerRepository = careerRepository;
            this.mapper = mapper;
        }

        public async override Task<IEnumerable<SharedPlayers.Player>> Handle(GetPlayersForTeamQuery query)
        {
            Career career = await this.careerRepository.GetByIdAsync(new CareerId(query.CareerId));
            return this.mapper.Map(career.Club.FirstTeam.Players.Select(tp => tp.Player));
        }
    }
}
