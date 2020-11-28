using System.Diagnostics;

namespace Footballista.Clubs.Domain.Teams
{
	[DebuggerDisplay("{_value}")]
	public record TeamType
	{
		private readonly string _value;

		public static TeamType FirstTeam => new TeamType(nameof(FirstTeam));
		public static TeamType SecondTeam => new TeamType(nameof(SecondTeam));

		private TeamType(string value)
		{
			_value = value;
		}

	}
}
