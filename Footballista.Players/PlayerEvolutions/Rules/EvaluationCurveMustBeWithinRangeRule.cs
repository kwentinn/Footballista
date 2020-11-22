using Footballista.BuildingBlocks.Domain;

namespace Footballista.Players.PlayerEvolutions.Rules
{
	public class EvaluationCurveMustBeWithinRangeRule : IBusinessRule
	{
		private const double MIN_VALUE = 0.1;
		private const double MAX_VALUE = 4;

		private readonly Range<double> _validRange = new Range<double>(MIN_VALUE, MAX_VALUE);
		private readonly double _value;

		public string Message => $"Evaluation curve value must be within range ({MIN_VALUE} to {MAX_VALUE}).";

		public EvaluationCurveMustBeWithinRangeRule(double value)
		{
			_value = value;
		}

		public bool IsBroken() => !_validRange.IsValueInRange(_value);
	}
}
