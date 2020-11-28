using Footballista.BuildingBlocks.Domain;

namespace Footballista.Players.Features.BusinessRules
{
	public class FeatureRatingMustBeWithinRangeRule : IBusinessRule
	{
		private readonly double _featureValue;

		private const double MIN_VALUE = 0d;
		private const double MAX_VALUE = 1d;

		private readonly Range<double> _validRange = new Range<double>(MIN_VALUE, MAX_VALUE);

		public string Message => $"A feature value must be between {MIN_VALUE} and {MAX_VALUE}.";

		public FeatureRatingMustBeWithinRangeRule(double featureValue)
		{
			_featureValue = featureValue;
		}

		public bool IsBroken()
		{
			return !_validRange.IsValueInRange(_featureValue);
		}
	}
}
