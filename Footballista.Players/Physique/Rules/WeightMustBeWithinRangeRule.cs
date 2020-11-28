using Footballista.BuildingBlocks.Domain;
using UnitsNet;
using UnitsNet.Units;

namespace Footballista.Players.Domain.Physique.Rules
{
	public class WeightMustBeWithinRangeRule : IBusinessRule
	{
		private static readonly Mass _minWeight = new Mass(25, MassUnit.Kilogram);
		private static readonly Mass _maxWeight = new Mass(250, MassUnit.Kilogram);
		private static readonly Range<Mass> _validRange = new Range<Mass>(_minWeight, _maxWeight);
		private readonly Mass _weight;

		public string Message => "Height is outside of the valid range";

		public WeightMustBeWithinRangeRule(Mass weight)
		{
			_weight = weight;
		}

		public bool IsBroken() => !_validRange.IsValueInRange(_weight);
	}
}
