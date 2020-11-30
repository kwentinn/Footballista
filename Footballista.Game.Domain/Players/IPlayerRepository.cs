using System.Collections.Generic;
using System.Threading.Tasks;

namespace Footballista.Game.Domain.Players
{
	public interface IPlayerRepository
	{
		Task SaveAsync(IEnumerable<Player> players);
	}
}
