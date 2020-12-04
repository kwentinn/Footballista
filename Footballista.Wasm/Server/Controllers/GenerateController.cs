using Footballista.Cqrs;
using Footballista.Cqrs.Queries.GetPlayersForTeam;
using Footballista.Wasm.Shared.Data.Players;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Footballista.Wasm.Server.Controllers
{
    [ApiController]
	[Route("[controller]")]
	public class GenerateController : ControllerBase
	{
		private readonly IMediatorWrapper mediator;

		public GenerateController(IMediatorWrapper mediator)
		{
			this.mediator = mediator;
		}

		[HttpGet]
		[Route("players/{maxPlayers}")]
		public async Task<IEnumerable<Player>> GetPlayersAsync(Guid careerId)
		{
			return await this.mediator.GetResultAsync(new GetPlayersForTeamQuery(careerId));
		}
	}
}
