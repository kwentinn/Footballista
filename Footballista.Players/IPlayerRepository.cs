using System.Collections.Generic;
using System.Threading.Tasks;

namespace Footballista.Players
{
    public interface IPlayerRepository
    {
        Task SaveAsync(IEnumerable<Player> players);
    }
}
