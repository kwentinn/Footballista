using System.Collections.Generic;
using System.Threading.Tasks;

namespace Footballista.Clubs.Domain
{
	public interface IClubRepository
	{
		Task<Club> GetByIdAsync(ClubId id);
		Task<IEnumerable<Club>> GetByIdsAsync(params ClubId[] ids);
	}
}
