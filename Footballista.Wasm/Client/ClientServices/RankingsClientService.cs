using Footballista.Wasm.Shared.Data.Competitions;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Footballista.Wasm.Client.ClientServices
{
	public class RankingsClientService : IRankingsClientService
	{
		private readonly HttpClient _httpClient;
		public RankingsClientService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}
		public async Task<List<CompetitionRanking>> GetRankings()
		{
			return await _httpClient.GetFromJsonAsync<List<CompetitionRanking>>("ranking");
		}
	}
}
