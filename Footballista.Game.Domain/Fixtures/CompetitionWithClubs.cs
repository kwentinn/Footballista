using Footballista.BuildingBlocks.Domain;
using Footballista.Game.Domain.Competitions;
using System.Collections.Generic;
using System.Linq;

namespace Footballista.Game.Domain.Fixtures
{
    public class CompetitionWithClubs
    {
        public CompetitionId Id { get; }
        public string Name { get; }

        private readonly List<ClubLight> clubs = new List<ClubLight>();

        public IReadOnlyCollection<ClubLight> Clubs => this.clubs.AsReadOnly();

        public CompetitionWithClubs(CompetitionId id, string name, IEnumerable<ClubLight> clubs)
        {
            Ensure.IsNotNull(id);
            Ensure.IsNotNull(name);
            Ensure.IsNotNullOrEmpty(clubs);

            this.Id = id;
            this.Name = name;
            this.clubs = clubs.ToList();
        }
    }
}
