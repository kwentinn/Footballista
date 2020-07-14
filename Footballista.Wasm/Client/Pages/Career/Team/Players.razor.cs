using Footballista.Wasm.Client.Domain.ClientServices;
using Footballista.Wasm.Shared.Data.Players;
using Microsoft.AspNetCore.Components;
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


		protected override async Task OnInitializedAsync()
		{
			players = await PlayersClientService.GetGeneratedPlayersAsync(20);
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
