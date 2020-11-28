using Footballista.BuildingBlocks.Domain;

namespace Footballista.Players.Domain.Physique.Rules
{
	public class BmiMustBeWithinRangeRule : IBusinessRule
	{
		private readonly double _bmi;

		private readonly Range<double> _validRange = new Range<double>(10, 35);

		public BmiMustBeWithinRangeRule(double bmi)
		{
			_bmi = bmi;
		}

		public string Message => "Bmi must be within range 10-35";

		public bool IsBroken() => !_validRange.IsValueInRange(_bmi);
	}
}