namespace Footballista.BuildingBlocks.Domain.ValueObjects.Rules
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
