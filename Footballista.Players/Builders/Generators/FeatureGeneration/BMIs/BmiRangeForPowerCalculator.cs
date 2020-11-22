using Footballista.BuildingBlocks.Domain;
using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Players.Features;
using Footballista.Players.Physique;

namespace Footballista.Players.Builders.Generators.FeatureGeneration
{
	public class BmiRangeForPowerCalculator : GenRangeCalculator
	{
		public override GenRange Calculate(BodyMassIndex bmi, PersonAge age)
		{
			Range<Rating> rangeForPower;
			if (bmi.BMI > 23 && bmi.Height.Centimeters >= 185)
			{
				rangeForPower = MaxRange;
			}
			else if (bmi.BMI < 22)
			{
				rangeForPower = MinRange;
			}
			else
			{
				rangeForPower = MediumRange;
			}

			// take player's age into account
			if (age > PersonAge.FromYears(25))
			{
				rangeForPower = new Range<Rating>(rangeForPower.Lower * 1.05, rangeForPower.Upper * 1.05);
			}
			else if (age < PersonAge.FromYears(20))
			{
				rangeForPower = new Range<Rating>(rangeForPower.Lower * 0.8, rangeForPower.Upper * 0.9);
			}
			return new GenRange(FeatureType.Power, rangeForPower);
		}
	}
}
