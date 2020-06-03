using Footballista.Wasm.Shared.Data.Players;
using System.Threading.Tasks;

namespace Footballista.Wasm.Server.Services
{
	public interface IPlayersService
	{
		Task<Player> GetPlayerAsync();
		Task<Player[]> GetPlayersAsync();
	}
}