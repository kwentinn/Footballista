using Footballista.Game.Domain.Clubs;
using Footballista.Game.Domain.Competitions;
using Footballista.Game.Domain.Competitions.Seasons;
using Itenso.TimePeriod;
using System.Threading.Tasks;

namespace Footballista.Game.Domain.Careers
{
    public interface ICareerDomainService
    {
        Task CreateCareerAsync(string name, ClubId clubId, CompetitionId competitionId, SeasonId seasonId, Date date, Manager manager);
    }

}
