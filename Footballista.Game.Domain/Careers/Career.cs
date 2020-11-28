using Itenso.TimePeriod;
using System;

namespace Footballista.Game.Domain.Careers
{
    public record CareerId(Guid Id)
    {
        public static CareerId New() => new CareerId(Guid.NewGuid());
    };
    public record Career
    {
        private CareerId id;

        private readonly string name;
        private readonly Club club;
        private readonly Competition competition;
        private readonly Date currentDate;
        private readonly Manager manager;
        private readonly Season season;

        public Career(string name, Club club, Competition competition, Date currentDate, Manager manager, Season season)
        {
            this.name = name;
            this.club = club;
            this.competition = competition;
            this.currentDate = currentDate;
            this.manager = manager;
            this.season = season;
        }
        public Career(CareerId id, string name, Club club, Competition competition, Date currentDate, Manager manager, Season season)
            :this(name, club, competition, currentDate, manager, season)
        {
            this.id = id;
        }
    }
}