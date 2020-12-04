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
}
