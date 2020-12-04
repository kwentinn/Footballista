using Footballista.Game.Domain.Players.Persons;
using System;
using System.Collections.Generic;

namespace Footballista.Game.Infrastructure.Entities
{
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
