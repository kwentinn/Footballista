namespace Footballista.Game.Domain.Careers
{
    public record Competition(CompetitionId Id, string Name);
    public record CompetitionId(int Value);
}