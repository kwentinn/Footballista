using System.Collections.Generic;
using System.Diagnostics;

namespace Footballista.Clubs.Domain.Teams
{
	[DebuggerDisplay("{TeamType} - {Coach}")]
	public record Team
	{
		public TeamType TeamType { get; }
		public Coach Coach { get; }

		private readonly List<TeamPlayer> _players = new List<TeamPlayer>();

		public Team
		(
			TeamType teamType,
			Coach coach, 
			List<TeamPlayer> teamPlayers
		)
		{
			TeamType = teamType;
			Coach = coach;
			_players = teamPlayers;
		}
	}
}
