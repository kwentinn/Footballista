using System.Collections.Generic;
using System.Diagnostics;

namespace Footballista.Clubs.Domain.Teams
{
    [DebuggerDisplay("{TeamType} - {Coach}")]
    public record Team
    {
        public TeamType TeamType { get; }
        public Coach Coach { get; }

        protected readonly List<TeamPlayer> Players = new List<TeamPlayer>();

        public Team
        (
            TeamType teamType,
            Coach coach,
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
        public FirstTeam(Coach coach, List<TeamPlayer> teamPlayers)
            : base(TeamType.FirstTeam, coach, teamPlayers)
        {
        }
    }
}
