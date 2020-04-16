using Footballista.BuildingBlocks.Domain;

namespace Footballista.Players.Features.BusinessRules
{
	public class FeatureRatingMustBeWithinRangeRule : IBusinessRule
	{
		private readonly double _featureValue;

		public string Message => "A feature value must be between 0 and 1.";

		public FeatureRatingMustBeWithinRangeRule(double featureValue)
		{
			this._featureValue = featureValue;
		}

		public bool IsBroken()
		{
			return _featureValue < 0.01 || _featureValue > 0.99;
		}
	}
}
