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
                .With(career.CurrentDate.ToDomain())
                //.With(career.Manager.ToDomain())
                //.With(career.Season.ToDomain())
                //.With(career.Competition.ToDomain())
                //.With(career.Season.ToDomain())
                .Build();
        }
        public static Club ToDomain(this ClubDb club)
        {
            return new ClubBuilder(club.Name)
                .WithId(new ClubId(club.Id))
                //.WithFirstTeam(club.FirstTeam.ToDomain())
                .Build();
        }
        public static Date ToDomain(this DateDb date) => new Date(date.Year, date.Month, date.Day);
        //public static FirstTeam ToDomain(this TeamDb team)
        //{
        //    return new FirstTeam(team.)
        //}

        public static Player ToDomain(this PlayerDb player)
        {
            PlayerPosition position = PlayerPosition.FromString(player.Position);
            return new PlayerBuilder()
                .WithId(new PersonId(player.Id))
                .WithName(new PersonName(new Firstname(player.Firstname), new Lastname(player.Lastname)))
                .WithPercentile(new Percentile(player.Percentile))
                .WithBodyMassIndex(new BodyMassIndex(new Length(player.HeightInCentimeters, LengthUnit.Centimeter), new Mass(player.WeightInKilograms, MassUnit.Kilogram)))
                .WithFoot(Enum.Parse<Foot>(player.Foot))
                .WithBirthInfo(new BirthInfo(player.Birthdate.ToDomain(), new Location(new City(player.CityOfBirth), Country.GetFromName(player.CountryOfBirth))))
                .WithCountries(GetCountriesFromString(player.Nationalities))
                .WithPlayerPosition(position)
                //.WithFeatureSet(PhysicalFeatureSet.Rehydrate(position.PositionCategory )
                .BuildRehydrate();
        }
        public static IEnumerable<Country> GetCountriesFromString(string coutriesSeparatedByCommas)
        {
            string[] countriesArray = coutriesSeparatedByCommas.Split(",");
            foreach (string country in countriesArray)
            {
                yield return Country.GetFromName(country);
            }
        }
    }
}
