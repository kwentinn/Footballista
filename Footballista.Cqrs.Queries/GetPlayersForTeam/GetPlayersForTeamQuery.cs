using Footballista.Cqrs.Base.Queries;
using Footballista.Wasm.Shared.Data.Players;
using System;
using System.Collections.Generic;

namespace Footballista.Cqrs.Queries.GetPlayersForTeam
{
    public sealed class GetPlayersForTeamQuery : IQuery<IEnumerable<Player>>
    {
        public Guid CareerId { get; }

        public GetPlayersForTeamQuery(Guid careerId)
        {
            this.CareerId = careerId;
        }
    }
}
