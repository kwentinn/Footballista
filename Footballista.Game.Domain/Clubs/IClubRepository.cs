using Footballista.Game.Domain.Competitions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Footballista.Game.Domain.Clubs
{
    public interface IClubRepository
    {
        Task<Club> GetByIdAsync(ClubId id);
        Task<IEnumerable<Club>> GetByIdsAsync(params ClubId[] ids);
        Task<IEnumerable<Club>> GetClubsInCompetition(CompetitionId competitionId);
    }
}
