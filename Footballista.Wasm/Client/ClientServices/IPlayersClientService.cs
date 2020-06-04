using Footballista.Wasm.Shared.Data.Players;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Footballista.Wasm.Client.ClientServices
{
	public interface IPlayersClientService
	{
		Task<List<Player>> GetGeneratedPlayersAsync(int maxPlayers = 50);
	}
}