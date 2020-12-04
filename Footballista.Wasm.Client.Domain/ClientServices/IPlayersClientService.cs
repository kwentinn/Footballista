using Footballista.Wasm.Shared.Data.Players;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Footballista.Wasm.Client.Domain.ClientServices
{
    public interface IPlayersClientService
	{
		Task<List<Player>> GetPlayersAsync(Guid careerId);
	}
}