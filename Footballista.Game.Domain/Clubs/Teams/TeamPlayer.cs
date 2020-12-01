using Footballista.Game.Domain.Players;

namespace Footballista.Game.Domain.Clubs.Teams
{
    public class TeamPlayer
    {
        public PlayerNumber PlayerNumber { get; }
        public Player Player { get; }

        public TeamPlayer(PlayerNumber playerNumber, Player player)
        {
            this.PlayerNumber = playerNumber;
            this.Player = player;
        }
    }
}
