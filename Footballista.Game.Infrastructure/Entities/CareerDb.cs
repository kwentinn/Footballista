using System;

namespace Footballista.Game.Infrastructure.Entities
{
    public class CareerDb
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ClubDb Club { get; set; }
        public CompetitionDb Competition { get; set; }
        public DateDb CurrentDate { get; set; }
        public ManagerDb Manager { get; set; }
        public SeasonDb Season { get; set; }

        public CareerDb() { }
    }

    public class DateDb
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
    }

    public class SeasonDb
    {
        public int Id { get; set; }
        public DateDb Start { get; set; }
    }

    public class ManagerDb
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }

    public class CompetitionDb
    {
        public int Id { get; set; }

    }

    public class ClubDb
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
