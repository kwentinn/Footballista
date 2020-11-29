using Itenso.TimePeriod;

namespace Footballista.Game.Domain.Careers
{
    public record Season(SeasonId Id, Date Start, Date End);
    public record SeasonId(int Value);
}