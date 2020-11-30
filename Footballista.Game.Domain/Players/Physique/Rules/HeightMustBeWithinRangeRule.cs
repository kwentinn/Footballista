using Footballista.BuildingBlocks.Domain;
using UnitsNet;
using UnitsNet.Units;

namespace Footballista.Game.Domain.Players.Physique.Rules
{
	public class HeightMustBeWithinRangeRule : IBusinessRule
	{
		private static readonly Length _minHeight = new Length(50, LengthUnit.Centimeter);
		private static readonly Length _maxHeight = new Length(250, LengthUnit.Centimeter);

		private static readonly Range<Length> _validRange = new Range<Length>(_minHeight, _maxHeight);

		private readonly Length _height;

		public string Message => "Height is outside of the valid range";

		public HeightMustBeWithinRangeRule(Length height)
		{
			_height = height;
		}

		public bool IsBroken() => !_validRange.IsValueInRange(_height);
	}
}
