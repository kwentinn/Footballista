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
		[Route("players")]
		public async Task<IEnumerable<Player>> GetGeneratedPlayersAsync()
		{
			return await _playersService.GetPlayersAsync(); //, new System.Threading.CancellationToken());
		}
	}
}
