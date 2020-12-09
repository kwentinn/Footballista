using Itenso.TimePeriod;
using System;

namespace Footballista.Game.Domain.Competitions.Seasons
{
    public class Season
    {
        public SeasonId Id { get; }
        public Date Start { get; }
        public Date End => new Date(this.Start.DateTime.AddYears(1));
        public ITimeRange Period => new TimeRange(this.Start.ToDateTime(0), this.End.ToDateTime(0));

        public int NumberOfWeeks => Convert.ToInt32(this.Period.Duration.TotalDays / 7);

        public Season(SeasonId id, Date start)
        {
            this.Id = id;
            this.Start = start;
        }
    }
}