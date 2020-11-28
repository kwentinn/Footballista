using System.Collections.Generic;
using System.Threading.Tasks;

namespace Footballista.Players.Domain
{
	public interface IPlayerRepository
	{
		Task SaveAsync(IEnumerable<Player> players);
	}
}
