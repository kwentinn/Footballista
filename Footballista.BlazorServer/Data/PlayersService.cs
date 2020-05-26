using Footballista.BlazorServer.Data.Mappers;
using Footballista.BlazorServer.Data.Players;
using Footballista.Players.Builders;
using System.Linq;
using System.Threading.Tasks;

namespace Footballista.BlazorServer.Data
{
	public class PlayersService
	{
		private readonly IPlayerBuilder _builder;
		private readonly IMapper<Footballista.Players.Player, Player> _mapper;

		public PlayersService(
			IPlayerBuilder builder,
			IMapper<Footballista.Players.Player, Player> mapper
		)
		{
			_builder = builder;
			_mapper = mapper;
		}

		public async Task<Player> GetPlayerAsync()
		{
			Footballista.Players.Player player = await _builder.BuildAsync();
			return _mapper.Map(player);
		}
		public async Task<Player[]> GetPlayersAsync()
		{
			var players = await _builder.BuildManyAsync(50);
			return _mapper.Map(players)?.ToArray();
		}
	}
}
