using System.Collections.Generic;
using System.Linq;

namespace Footballista.Game.Domain.Competitions
{
    public interface ICompetitionRepository
    {
        Competition GetById(CompetitionId id);
    }
    public class CompetitionRepository : ICompetitionRepository
    {
        private static readonly List<Competition> _competitions = new List<Competition>
        {
            Competition.Ligue1, Competition.Ligue2
        };

        public Competition GetById(CompetitionId id)
        {
            return _competitions.FirstOrDefault(c => c.Id == id);
        }
    }
}
