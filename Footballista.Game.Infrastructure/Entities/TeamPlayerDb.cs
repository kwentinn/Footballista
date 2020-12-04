namespace Footballista.Game.Infrastructure.Entities
{
    public class TeamPlayerDb
    {
        public int PlayerNumber { get; set; }
        public PlayerDb Player { get; set; }
    }
}
