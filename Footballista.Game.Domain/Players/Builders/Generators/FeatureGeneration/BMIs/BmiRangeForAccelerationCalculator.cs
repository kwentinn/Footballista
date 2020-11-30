using Footballista.BuildingBlocks.Domain;
using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Game.Domain.Players.Builders.Generators.FeatureGeneration;
using Footballista.Game.Domain.Players.Features;
using Footballista.Game.Domain.Players.Physique;

namespace Footballista.Players.Builders.Generators.FeatureGeneration
{
	public class BmiRangeForAccelerationCalculator : GenRangeCalculator
	{
		public override GenRange Calculate(BodyMassIndex bmi, PersonAge age)
		{
			Range<Rating> rangeForSpeed;
			if (bmi.BMI > 22.8)
			{
				rangeForSpeed = MinRange;
			}
			else if (bmi.BMI < 21.2)
			{
				rangeForSpeed = MaxRange;
			}
			else
			{
				rangeForSpeed = MediumRange;
			}

			// take player age into account
			if (age > PersonAge.FromYears(30))
			{
				rangeForSpeed = new Range<Rating>(rangeForSpeed.Lower * 0.82, rangeForSpeed.Upper * 0.88);
			}
			else if (age < PersonAge.FromYears(23))
			{
				rangeForSpeed = new Range<Rating>(rangeForSpeed.Lower * 1.052, rangeForSpeed.Upper * 1.055);
			}
			return new GenRange(FeatureType.Acceleration, rangeForSpeed);
		}
	}
}
