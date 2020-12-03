using Footballista.Game.Domain.Players.Persons;
using System;
using System.Collections.Generic;

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
        public string Name { get; set; }
    }

    public class ClubDb
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public TeamDb FirstTeam { get; set; }

    }

    public class TeamDb
    {
        public virtual ICollection<TeamPlayerDb> TeamPlayers { get; set; }
    }
    public class TeamPlayerDb
    {
        public int PlayerNumber { get; set; }
        public PlayerDb Player { get; set; }
    }
    public class PlayerDb
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Nationalities { get; set; }
        public string Foot { get; set; }
        public Gender Gender { get; set; }
        public int Percentile { get; set; }
        public string Position { get; set; }
        public int GeneralRating { get; set; }
        public DateDb Birthdate { get; set; }
        public string CityOfBirth { get; set; }
        public string CountryOfBirth { get; set; }
        public double HeightInCentimeters { get; set; }
        public double WeightInKilograms { get; set; }
        public Dictionary<string, int> Ratings { get; set; }
    }
}
