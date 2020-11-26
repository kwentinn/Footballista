using Footballista.BuildingBlocks.Domain;
using System.Diagnostics;

namespace Footballista.Players.Positions
{
	[DebuggerDisplay("{name}")]
	public class PositionCategory : ValueObject
	{
		public readonly string name;

		private PositionCategory(string name)
		{
			this.name = name;
		}

		public static PositionCategory GoalKeeper => new PositionCategory(nameof(GoalKeeper));
		public static PositionCategory Defender => new PositionCategory(nameof(Defender));
		public static PositionCategory Midfielder => new PositionCategory(nameof(Midfielder));
		public static PositionCategory Forward => new PositionCategory(nameof(Forward));

		public static PositionCategory None => new PositionCategory(nameof(None));
    }
}
