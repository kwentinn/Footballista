using Footballista.BuildingBlocks.Domain;
using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Players.Domain.Builders.Generators.FeatureGeneration;
using Footballista.Players.Domain.Features;
using Footballista.Players.Domain.Physique;
using UnitsNet;
using UnitsNet.Units;

namespace Footballista.Players.Builders.Generators.FeatureGeneration
{
	public class BmiRangeForHeaderCalculator : GenRangeCalculator
	{

		private readonly Length _minimuHeightForMaxRange = new Length(180, LengthUnit.Centimeter);
		private readonly Length _minimuHeightForMinRange = new Length(165, LengthUnit.Centimeter);

		public override GenRange Calculate(BodyMassIndex bmi, PersonAge age)
		{
			Range<Rating> rangeForHeader;
			if (bmi.Height >= _minimuHeightForMaxRange)
			{
				rangeForHeader = MaxRange;
			}
			else if (bmi.Height < _minimuHeightForMinRange)
			{
				rangeForHeader = MinRange;
			}
			else
			{
				rangeForHeader = MediumRange;
			}
			return new GenRange(FeatureType.Header, rangeForHeader);
		}
	}
}
