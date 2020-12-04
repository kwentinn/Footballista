using Footballista.Wasm.Client.Domain.ClientServices;
using Footballista.Wasm.Shared.Data.Players;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Footballista.Wasm.Client.Pages.Career.Team
{
    public partial class Players
	{
		private List<Player> players;
		private Player _selectedPlayer;

		[Inject]
		public IPlayersClientService PlayersClientService { get; set; }

		[Inject]
		public IGameService GameService { get; set; }


		protected override async Task OnInitializedAsync()
		{
            Guid careerId = GameService.CurrentGame.Id;
			players = await PlayersClientService.GetPlayersAsync(careerId);
		}

		private void OnPlayerSelect(Player selectedPlayer)
		{
			if (_selectedPlayer == null || (_selectedPlayer.Id != selectedPlayer.Id))
			{
				_selectedPlayer = selectedPlayer;
			}
		}
	}
}
