using Footballista.Game.Domain.Careers;
using Footballista.Game.Domain.Clubs;
using Footballista.Game.Domain.Clubs.Teams;
using Footballista.Game.Domain.Competitions;
using Footballista.Game.Domain.Players;
using Footballista.Game.Domain.Players.Features;
using Footballista.Game.Infrastructure.Entities;
using Itenso.TimePeriod;
using System.Collections.Generic;
using System.Linq;

namespace Footballista.Game.Infrastructure
{
    public static class DomainToDbExtensions
    {
        public static CareerDb ToDb(this Career career)
        {
            return new CareerDb
            {
                Id = career.Id,
                CurrentDate = career.CurrentDate.ToDb(),
                Name = career.Name,
                Club = career.Club.ToDb(),
                Manager = career.Manager.ToDb()
            };
        }
        public static ClubDb ToDb(this Club club)
        {
            return new ClubDb()
            {
                Id = club.Id,
                Name = club.Name,
                FirstTeam = club.FirstTeam.ToDb()
            };
        }
        public static TeamDb ToDb(this Team team)
        {
            return new TeamDb
            {
                TeamPlayers = team.Players.ToDb()
            };
        }
        public static ICollection<TeamPlayerDb> ToDb(this IEnumerable<TeamPlayer> teamPlayers)
        {
            return teamPlayers
                .Select(p => p.ToDb())
                .ToList();
        }
        public static TeamPlayerDb ToDb(this TeamPlayer teamPlayer)
        {
            return new TeamPlayerDb
            {
                PlayerNumber = teamPlayer.PlayerNumber,
                Player = teamPlayer.Player.ToDb()
            };
        }
        public static PlayerDb ToDb(this Player player)
        {
            return new PlayerDb
            {
                Id = player.Id,
                Firstname = player.Name.Firstname.Value,
                Lastname = player.Name.Lastname.Value,
                Nationalities = string.Join(", ", player.Nationalities.Select(n => n.CountryCode)),
                Birthdate = player.BirthInfo.Date.ToDb(),
                CityOfBirth = player.BirthInfo.Location.City.Name,
                CountryOfBirth = player.BirthInfo.Location.Country.RegionInfo.EnglishName,
                Foot = player.FavouriteFoot.ToString(),
                HeightInCentimeters = player.Bmi.Height.Centimeters,
                WeightInKilograms = player.Bmi.Weight.Kilograms,
                Gender = player.Gender,
                Percentile = player.Percentile.Value,
                Position = player.PlayerPosition.Name,
                GeneralRating = player.GeneralRating.ToRoundedPercent(),
                Ratings = player.PhysicalFeatureSet.PhysicalFeatures.ToDb()
            };

        }
        public static Dictionary<string, int> ToDb(this IReadOnlyCollection<PhysicalFeature> physicalFeatures)
        {
            return physicalFeatures.ToDictionary(f => f.FeatureType.ToString(), f => f.Rating.ToRoundedPercent());
        }
        public static ManagerDb ToDb(this Manager manager)
        {
            return new ManagerDb
            {
                Id = manager.Id,
                Firstname = manager.Firstname,
                Lastname = manager.Lastname,
            };
        }
        public static DateDb ToDb(this Date date)
        {
            return new DateDb
            {
                Year = date.Year,
                Month = date.Month,
                Day = date.Day
            };
        }
        private static CompetitionDb ToDb(this Competition competition)
        {
            return new CompetitionDb
            {
                Id = competition.Id,
                Name = competition.Name
            };
        }
    }
}
