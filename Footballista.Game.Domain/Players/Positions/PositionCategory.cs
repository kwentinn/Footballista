using System.Diagnostics;

namespace Footballista.Game.Domain.Players.Positions
{
	[DebuggerDisplay("{_name}")]
	public record PositionCategory
	{
		private readonly string _name;

		private PositionCategory(string name)
		{
			_name = name;
		}

		public static PositionCategory GoalKeeper => new PositionCategory(nameof(GoalKeeper));
		public static PositionCategory Defender => new PositionCategory(nameof(Defender));
		public static PositionCategory Midfielder => new PositionCategory(nameof(Midfielder));
		public static PositionCategory Forward => new PositionCategory(nameof(Forward));

		public static PositionCategory None => new PositionCategory(nameof(None));
	}
}
