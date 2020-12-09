using Itenso.TimePeriod;
using System.Collections.Generic;
using System.Linq;

namespace Footballista.Game.Domain.Fixtures
{
    public class Fixture
    {
        public FixtureId Id { get; }
        public int FixtureNumber { get; }
        public ITimeRange Period { get; }

        public IReadOnlyCollection<Match> FixtureMatches => this.fixtureMatches.AsReadOnly();
        private readonly List<Match> fixtureMatches = new List<Match>();

        public Fixture(
            FixtureId id,
            int fixtureNumber,
            ITimeRange period,
            IEnumerable<Match> fixtureMatches)
        {
            this.Id = id;
            this.FixtureNumber = fixtureNumber;
            this.Period = period;
            this.fixtureMatches = fixtureMatches.ToList();
        }
        public Fixture(
          FixtureId id,
          int fixtureNumber,
          ITimeRange fixtureDates)
            : this(id, fixtureNumber, fixtureDates, Enumerable.Empty<Match>())
        {
        }

        internal void SetFixtureMatches(IEnumerable<Match> matches)
        {
            this.fixtureMatches.Clear();
            this.fixtureMatches.AddRange(matches);
        }
    }
    public record FixtureId(int Value);
}
