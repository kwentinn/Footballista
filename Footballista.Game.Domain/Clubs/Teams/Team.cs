using System.Collections.Generic;
using System.Diagnostics;

namespace Footballista.Game.Domain.Clubs.Teams
{
    [DebuggerDisplay("{TeamType} - {Coach}")]
    public record Team
    {
        public TeamType TeamType { get; }
        public Manager Coach { get; }

        protected readonly List<TeamPlayer> Players = new List<TeamPlayer>();

        public Team
        (
            TeamType teamType,
            Manager coach,
            List<TeamPlayer> teamPlayers
        )
        {
            TeamType = teamType;
            Coach = coach;
            Players = teamPlayers;
        }
    }

    public record FirstTeam : Team
    {
        public FirstTeam(Manager coach, List<TeamPlayer> teamPlayers)
            : base(TeamType.FirstTeam, coach, teamPlayers)
        {
        }
    }
}
