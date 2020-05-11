using Footballista.BuildingBlocks.Domain;

namespace Footballista.Players.PlayerEvolutions.Rules
{
	public class DurationMustBeGreaterThanZeroRule : IBusinessRule
	{
		private readonly double _years;

		public DurationMustBeGreaterThanZeroRule(double years)
		{
			_years = years;
		}

		public string Message => "Duration must be greather than zero.";

		public bool IsBroken() => _years <= 0;
	}
}
