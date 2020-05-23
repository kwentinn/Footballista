using Footballista.BuildingBlocks.Domain;

namespace Footballista.Players.Physique.Rules
{
	public class BmiMustBeWithinRangeRule : IBusinessRule
	{
		private readonly double _bmi;

		private readonly Range<double> _validRange = new Range<double>(10, 30);

		public BmiMustBeWithinRangeRule(double bmi)
		{
			_bmi = bmi;
		}

		public string Message => "Bmi must be within range 10-30";

		public bool IsBroken() => !_validRange.IsValueInRange(this._bmi);
	}
}