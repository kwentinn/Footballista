namespace Footballista.Game.Domain.Competitions
{
    public record Competition
    {
        public CompetitionId Id { get; }
        public string Name { get; }

        private Competition(CompetitionId id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public static Competition Ligue1 => new Competition(new CompetitionId(1), "Ligue 1");
        public static Competition Ligue2 => new Competition(new CompetitionId(2), "Ligue 2");

    }
    public record CompetitionId(int Value);
}