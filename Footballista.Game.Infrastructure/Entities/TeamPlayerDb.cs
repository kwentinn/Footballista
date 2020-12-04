namespace Footballista.Game.Infrastructure.Entities
{
    public class TeamPlayerDb
    {
        public short PlayerNumber { get; set; }
        public PlayerDb Player { get; set; }
    }
}
