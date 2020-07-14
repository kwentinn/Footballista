﻿using Footballista.Players.Builders;
using Footballista.Wasm.Shared;
using Footballista.Wasm.Shared.Data.Players;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Footballista.Wasm.Server.Services
{
	public class PlayersService : IPlayersService
	{
		private readonly IPlayerBuilder _builder;
		private readonly IMapper<Players.Player, Player> _mapper;

		public PlayersService(
			IPlayerBuilder builder,
			IMapper<Players.Player, Player> mapper
		)
		{
			_builder = builder;
			_mapper = mapper;
		}

		public async Task<Player> GetPlayerAsync()
		{
			Players.Player player = await _builder.BuildAsync();
			return _mapper.Map(player);
		}
		public async Task<Player[]> GetPlayersAsync(int maxPlayers = 50)
		{
			var players = await _builder.BuildManyAsync(maxPlayers);
			return _mapper.Map(players)?.ToArray();
		}
	}
}
