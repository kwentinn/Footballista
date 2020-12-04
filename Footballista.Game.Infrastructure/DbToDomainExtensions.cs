using Footballista.BuildingBlocks.Domain.Percentiles;
using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Game.Domain.Careers;
using Footballista.Game.Domain.Clubs;
using Footballista.Game.Domain.Clubs.Teams;
using Footballista.Game.Domain.Players;
using Footballista.Game.Domain.Players.Features;
using Footballista.Game.Domain.Players.Persons;
using Footballista.Game.Domain.Players.Physique;
using Footballista.Game.Domain.Players.PlayerNames;
using Footballista.Game.Domain.Players.Positions;
using Footballista.Game.Infrastructure.Entities;
using Footballista.Players.Builders;
using Itenso.TimePeriod;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnitsNet;
using UnitsNet.Units;

namespace Footballista.Game.Infrastructure
{
    public static class DbToDomainExtensions
    {
        public static Career ToDomain(this CareerDb career)
        {
            return Career.RehydrateWithBuilder()
                .With(new CareerId(career.Id))
                .With(career.Club.ToDomain())
                .With(career.CurrentDate.ToDate())
                //.With(career.Manager.ToDomain())
                //.With(career.Season.ToDomain())
                //.With(career.Competition.ToDomain())
                //.With(career.Season.ToDomain())
                .Build();
        }
        public static Club ToDomain(this ClubDb club)
        {
            return new ClubRehydrator()
                .WithId(new ClubId(club.Id))
                .WithClubName(new ClubName(club.Name, club.Abbreviation))
                .WithFirstTeam(club.FirstTeam.ToDomain())
                .Rehydrate();
        }
        public static Date ToDate(this DateDb date) => new Date(date.Year, date.Month, date.Day);
        public static FirstTeam ToDomain(this TeamDb team)
        {
            return new FirstTeam(team.Manager.ToDomain(), team.TeamPlayers
                .Select(tp => new TeamPlayer(new PlayerNumber(tp.PlayerNumber), tp.Player.ToDomain()))
                .ToList());
        }
        public static Manager ToDomain(this ManagerDb manager)
        {
            return new Manager(manager.Id, manager.Firstname, manager.Lastname);
        }
        public static Player ToDomain(this PlayerDb player)
        {
            PlayerPosition position = PlayerPosition.FromString(player.Position);

            return new PlayerRehydrator()
                .WithId(new PersonId(player.Id))
                .WithFirstname(new Firstname(player.Firstname))
                .WithLastname(new Lastname(player.Lastname))
                .WithPercentile(new Percentile(player.Percentile))
                .WithHeight(new Length(player.HeightInCentimeters, LengthUnit.Centimeter))
                .WithMass(new Mass(player.WeightInKilograms, MassUnit.Kilogram))
                .WithFoot(Enum.Parse<Foot>(player.Foot))
                .WithBirthdate(player.Birthdate.ToDate())
                .WithBirthLocation(new Location(new City(player.CityOfBirth), Country.GetFromName(player.CountryOfBirth)))
                .WithCountries(GetCountriesFromString(player.Nationalities))
                .WithPlayerPosition(position)
                .WithFeatureSet(PhysicalFeatureSet.Rehydrate(position.PositionCategory, GetPhysicalFeaturesFromRatings(player.Ratings)))
                .Rehydrate();
        }
        public static IEnumerable<Country> GetCountriesFromString(string coutriesSeparatedByCommas)
        {
            string[] countriesArray = coutriesSeparatedByCommas.Split(",");
            foreach (string country in countriesArray)
            {
                yield return Country.GetFromName(country);
            }
        }

        public static IEnumerable<PhysicalFeature> GetPhysicalFeaturesFromRatings(Dictionary<string, int> ratings)
        {
            foreach (KeyValuePair<string, int> rating in ratings)
            {
                yield return new PhysicalFeature(Enum.Parse<FeatureType>(rating.Key), Rating.FromInt(rating.Value));
            }
        }
    }
}
