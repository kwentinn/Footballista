using FluentAssertions;
using Footballista.Game.Domain.Clubs;
using Footballista.Game.Domain.Competitions;
using Footballista.Game.Domain.Competitions.Seasons;
using Footballista.Game.Domain.Fixtures;
using Footballista.Players.Builders.Randomisers;
using Itenso.TimePeriod;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Footballista.Game.UnitTests
{
    [TestClass]
    public class FixtureGeneratorTest
    {

        public object FixtureGenerator { get; private set; }

        private static IEnumerable<ClubLight> GenerateClubLights(int numberOfClubs)
        {
            for (var i = 0; i < numberOfClubs; i++)
            {
                yield return new ClubLight(new ClubId(i), new ClubName($"Club {i}", $"C{i}"));
            }
        }

        [TestMethod]
        public void Generate()
        {
            const int numberOfClubs = 20;


            IEnumerable<ClubLight> generatedClubs = GenerateClubLights(numberOfClubs);

            Date seasonStart = new Date(2020, 7, 1);
            IEnumerable<Fixture> fixtures = new FixturesGenerator()
                .WithCompetition(Competition.Ligue1)
                .WithClubs(generatedClubs)
                .WithSeason(new Season(new SeasonId(1), seasonStart))
                .WithHomeAndAwayFixtures(true)
                .WithIntRandomiser(new MultipleIntValuesRandomiser())
                .Generate();

            fixtures.Should().NotBeNull();
            fixtures.Should().HaveCount(2);

            fixtures.Should().SatisfyRespectively(
                firstFixture =>
                {
                    firstFixture.Id.Should().BeEquivalentTo(new FixtureId(0));
                    firstFixture.FixtureNumber.Should().Be(1);
                    firstFixture.FixtureMatches.Should().SatisfyRespectively(
                        firstMatch =>
                        {
                            firstMatch.HomeClub.Should().BeEquivalentTo(new ClubLight(new ClubId(0), new ClubName("Club 0", "C0")));
                            firstMatch.AwayClub.Should().BeEquivalentTo(new ClubLight(new ClubId(1), new ClubName("Club 1", "C1")));
                        });
                },
                secondFixture =>
                {
                    secondFixture.Id.Should().BeEquivalentTo(new FixtureId(0));
                    secondFixture.FixtureNumber.Should().Be(1);
                    secondFixture.FixtureMatches.Should().SatisfyRespectively(
                        firstMatch =>
                        {
                            firstMatch.HomeClub.Should().BeEquivalentTo(new ClubLight(new ClubId(1), new ClubName("Club 1", "C1")));
                            firstMatch.AwayClub.Should().BeEquivalentTo(new ClubLight(new ClubId(0), new ClubName("Club 0", "C0")));
                        });
                }
            );
        }
    }
}
