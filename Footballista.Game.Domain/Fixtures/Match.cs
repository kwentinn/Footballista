using System;

namespace Footballista.Game.Domain.Fixtures
{
    public class Match
    {
        public MatchId Id { get; }
        public ClubLight HomeClub { get; }
        public ClubLight AwayClub { get; }
        public DateTime FixtureDate { get; }

        public Match(MatchId id, ClubLight homeClub, ClubLight awayClub, DateTime fixtureDate)
        {
            this.Id = id;
            this.HomeClub = homeClub;
            this.AwayClub = awayClub;
            this.FixtureDate = fixtureDate;
        }
    }
    public record MatchId(int Value);
}
