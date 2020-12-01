using Footballista.Game.Domain.Players;
using System.Collections.Generic;
using System.Diagnostics;

namespace Footballista.Game.Domain.Clubs.Teams
{
    [DebuggerDisplay("{TeamType} - {Coach}")]
    public class Team
    {
        public TeamType TeamType { get; }
        public Manager Manager { get; }

        public IReadOnlyCollection<TeamPlayer> Players => this.players.AsReadOnly();
        protected readonly List<TeamPlayer> players = new List<TeamPlayer>();

        public Team(TeamType teamType, Manager manager, List<TeamPlayer> teamPlayers)
        {
            this.TeamType = teamType;
            this.Manager = manager;
            this.players = teamPlayers;
        }

        internal void AddPlayers(Player[] players)
        {
            short playerNumber = 1;
            foreach (Player player in players)
            {
                this.players.Add(new TeamPlayer(new PlayerNumber(playerNumber), player));
                playerNumber++;
            }
        }
        internal void AddPlayers(IEnumerable<Player> players)
        {
            short playerNumber = 1;
            foreach (Player player in players)
            {
                this.players.Add(new TeamPlayer(new PlayerNumber(playerNumber), player));
                playerNumber++;
            }
        }
    }

    public class FirstTeam : Team
    {
        public FirstTeam(Manager manager, List<TeamPlayer> teamPlayers)
            : base(TeamType.FirstTeam, manager, teamPlayers)
        {
        }
    }
}
