using Itenso.TimePeriod;
using System;

namespace Footballista.Game.Domain.Careers
{
    public record Career
    {
        private Guid id;
        private readonly string name;
        private readonly Club club;
        private readonly Competition competition;
        private readonly Date currentDate;
        private readonly Manager manager;
        private readonly Season season;

        public Career(Guid id, string name, Club club, Competition competition, Date currentDate, Manager manager, Season season)
        {
            this.id = id;
            this.name = name;
            this.club = club;
            this.competition = competition;
            this.currentDate = currentDate;
            this.manager = manager;
            this.season = season;
        }
    }
}