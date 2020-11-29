using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footballista.Game.Domain.Competitions
{
    public interface ICompetitionRepository
    {
        Competition GetById(CompetitionId id);
    }
    public class CompetitionRepository : ICompetitionRepository
    {
        private static readonly List<Competition> competitions = new List<Competition>
        {

        };

        public Competition GetById(CompetitionId id)
        {
            return competitions.FirstOrDefault(c => c.Id == id);
        }
    }
}
