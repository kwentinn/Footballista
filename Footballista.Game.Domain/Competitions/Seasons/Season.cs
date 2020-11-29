using Itenso.TimePeriod;

namespace Footballista.Game.Domain.Competitions.Seasons
{
    public record Season(SeasonId Id, Date Start)
    {
        public Date End => new Date(Start.DateTime.AddYears(1));
    }
}