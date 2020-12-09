using Footballista.BuildingBlocks.Domain;
using Footballista.Game.Domain.Competitions;
using Footballista.Game.Domain.Competitions.Seasons;
using Footballista.Game.Domain.Fixtures.TimeSlots;
using Footballista.Players.Builders.Randomisers;
using Itenso.TimePeriod;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Footballista.Game.Domain.Fixtures
{
    public class FixturesGenerator
    {
        private bool homeAndAwayFixtures;
        private Season season;
        private Competition competition;
        private IEnumerable<ClubLight> clubs;
        private IMultipleValuesRandomiser<int> randomiser;

        public FixturesGenerator WithHomeAndAwayFixtures(bool homeAndAwayFixtures)
        {
            this.homeAndAwayFixtures = homeAndAwayFixtures;
            return this;
        }
        public FixturesGenerator WithSeason(Season season)
        {
            this.season = season;
            return this;
        }
        public FixturesGenerator WithCompetition(Competition competition)
        {
            this.competition = competition;
            return this;
        }
        public FixturesGenerator WithClubs(IEnumerable<ClubLight> clubs)
        {
            this.clubs = clubs;
            return this;
        }
        public FixturesGenerator WithIntRandomiser(IMultipleValuesRandomiser<int> randomiser)
        {
            this.randomiser = randomiser;
            return this;
        }

        public FixturesGenerator()
        {

        }

        public IEnumerable<Fixture> Generate()
        {
            int numberOfTeams = this.clubs.Count();
            int numberOfFixtures = (numberOfTeams - 1) * (this.homeAndAwayFixtures ? 2 : 1);
            int numberOfMatches = (numberOfTeams / 2) * numberOfFixtures;

            // calculer le nombre de semaines disponibles
            if (numberOfFixtures > this.season.NumberOfWeeks)
            {
                throw new CannotGenerateFixturesForSeason();
            }

            // calculer les dates des journées en fonction 
            // - du nombre d'équipes,
            // - du nombre de journées, 
            // - de la période de la saison.
            // - tous les matches sont-ils joués le même jour ?
            // - uniquement le weekend ?

            //Day startDay = new Day(this.season.Start.ToDateTime(0));
            TimeSlotConfiguration ligue1TimeSlotConfig = new TimeSlotConfiguration()
                .WithAvailableTimeSlots(new TimeSlot[]
                {
                    new TimeSlot(DayOfWeek.Friday, hour: 20),
                    new TimeSlot(DayOfWeek.Saturday, hour: 14),
                    new TimeSlot(DayOfWeek.Saturday, hour: 17),
                    new TimeSlot(DayOfWeek.Saturday, hour: 21, allowMultiple: false),
                    new TimeSlot(DayOfWeek.Sunday, hour: 17),
                    new TimeSlot(DayOfWeek.Sunday, hour: 21, allowMultiple: false),
                })
                .WithFirstDayOfWeek(DayOfWeek.Monday);

            // pick 38 weeks randomly in the period
            IEnumerable<int> randomisedWeeks = randomiser.RandomiseDistinctValues(new Range<int>(0, this.season.NumberOfWeeks - 1), numberOfFixtures)
                .OrderBy(i => i);

            IEnumerable<Week> weeksWithMatches = this.ChooseRandomlyWeeksInSeasonPeriod(this.season.Period, randomisedWeeks);


            IEnumerable<TimeSlotConfiguration.AvailableDatesForWeek> availableDatesForWeeks = ligue1TimeSlotConfig.GetAllAvailableDatesForWeeks(this.season.Period);

           

            return null;

            //List<Fixture> fixtures = new List<Fixture>();
            //// pour chaque journée, on doit calculer la date ou la période de déroulement de l'évènement
            //// sans répartition ds un premier temps
            //DateTime fixtureStart = this.season.Start.ToDateTime(0);
            //for (int fixtureNumber = 1; fixtureNumber <= numberOfFixtures; fixtureNumber++)
            //{

            //    ITimeRange period = new TimeRange();
            //    fixtures.Add(new Fixture(new FixtureId(fixtureNumber), fixtureNumber, period));
            //}

            //// premièere partie de saison => J1 à J19
            //Range<int> seasonFirstPart = new Range<int>(1, numberOfFixtures / 2); // 1 -> 19

            //// deuxième => J20 à J38
            //Range<int> seasonSecondPart = new Range<int>((numberOfFixtures / 2) + 1, numberOfFixtures); // 20 -> 38




            //FixtureMatchGenerator matchGenerator = new FixtureMatchGenerator()
            //    .WithSeason(this.season);

            //for (int fixtureNumber = 0; fixtureNumber < numberOfFixtures; fixtureNumber++)
            //{
            //    Fixture fixture = new Fixture(new FixtureId(fixtureNumber + 1), fixtureNumber + 1, this.season.Period);

            //    IEnumerable<Match> matches = matchGenerator
            //        .WithFixture(fixture)
            //        .WithTimeSlotConfiguration(new TimeSlotConfiguration())
            //        .GenerateMatchesForFixture();

            //    fixture.SetFixtureMatches(matches);
            //}
        }

        private IEnumerable<Week> ChooseRandomlyWeeksInSeasonPeriod(ITimeRange period, IEnumerable<int> randomisedWeeks)
        {
            foreach (var weeksToAdd in randomisedWeeks)
            {
                var date = period.Start.AddDays(7 * weeksToAdd);
                yield return new Week(date);
            }
        }
    }



    public class FixtureMatchGenerator
    {
        private record MatchFixture(Match Match, FixtureId FixtureId);
        private readonly List<MatchFixture> matchFixtures = new List<MatchFixture>();
        private Fixture fixture;
        private Season season;
        private TimeSlotConfiguration timeSlotConfiguration;

        public FixtureMatchGenerator WithFixture(Fixture fixture)
        {
            this.fixture = fixture;
            return this;
        }
        public FixtureMatchGenerator WithSeason(Season season)
        {
            this.season = season;
            return this;
        }
        public FixtureMatchGenerator WithTimeSlotConfiguration(TimeSlotConfiguration timeSlotConfiguration)
        {
            this.timeSlotConfiguration = timeSlotConfiguration;
            return this;
        }

        public IEnumerable<Match> GenerateMatchesForFixture()
        {
            for (int weekNumber = 0; weekNumber < this.season.NumberOfWeeks; weekNumber++)
            {
                Week week = new Week(this.season.Start.ToDateTime(0));
                DateTime lastDayOfWeek = week.LastDayOfWeek;


            }
            return null;
        }
    }
}
