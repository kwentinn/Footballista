using Footballista.Wasm.Shared.Data.Players;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Footballista.Wasm.Client.ClientServices
{
	public class PlayersClientService : IPlayersClientService
	{
		private readonly HttpClient _httpClient;

		public PlayersClientService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}
		public async Task<List<Player>> GetGeneratedPlayersAsync(int maxPlayers = 50) //, CancellationToken cancellationToken = default)
		{
			return await _httpClient.GetFromJsonAsync<List<Player>>("generate/players"); //, cancellationToken);
		}
	}
}
