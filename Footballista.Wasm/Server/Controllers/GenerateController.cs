using Footballista.Wasm.Server.Services;
using Footballista.Wasm.Shared.Data.Players;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Footballista.Wasm.Server.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class GenerateController : ControllerBase
	{
		private readonly IPlayersService _playersService;

		public GenerateController(IPlayersService playersService)
		{
			_playersService = playersService;
		}

		[HttpGet]
		[Route("players/{maxPlayers}")]
		public async Task<IEnumerable<Player>> GetGeneratedPlayersAsync(int maxPlayers)
		{
			return await _playersService.GetPlayersAsync(maxPlayers);
		}
	}
}
