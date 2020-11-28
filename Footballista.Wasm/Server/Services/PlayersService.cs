using Footballista.Players.Builders;
using Footballista.Wasm.Shared;
using System.Linq;
using System.Threading.Tasks;

namespace Footballista.Wasm.Server.Services
{
	public class PlayersService : IPlayersService
	{
		private readonly IPlayerGenerator _builder;
		private readonly IMapper<Players.Domain.Player, Shared.Data.Players.Player> _mapper;

		public PlayersService(
			IPlayerGenerator builder,
			IMapper<Players.Domain.Player, Shared.Data.Players.Player> mapper
		)
		{
			_builder = builder;
			_mapper = mapper;
		}

		public async Task<Shared.Data.Players.Player> GetPlayerAsync()
		{
			Players.Domain.Player player = await _builder.GenerateAsync();
			return _mapper.Map(player);
		}
		public async Task<Shared.Data.Players.Player[]> GetPlayersAsync(int maxPlayers = 50)
		{
			Players.Domain.Player[] players = await _builder.GenerateManyAsync(maxPlayers);
			return _mapper.Map(players)?.ToArray();
		}
	}
}
