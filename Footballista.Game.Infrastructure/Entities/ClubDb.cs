namespace Footballista.Game.Infrastructure.Entities
{
    public class ClubDb
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public TeamDb FirstTeam { get; set; }

    }
}
