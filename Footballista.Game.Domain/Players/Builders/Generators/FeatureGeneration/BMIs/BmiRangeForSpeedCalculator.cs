using Footballista.BuildingBlocks.Domain;
using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Game.Domain.Players.Builders.Generators.FeatureGeneration;
using Footballista.Game.Domain.Players.Features;
using Footballista.Game.Domain.Players.Physique;

namespace Footballista.Players.Builders.Generators.FeatureGeneration
{
	public class BmiRangeForSpeedCalculator : GenRangeCalculator
	{
		public override GenRange Calculate(BodyMassIndex bmi, PersonAge age)
		{
			Range<Rating> rangeForSpeed;
			if (bmi.BMI > 23.5)
			{
				rangeForSpeed = MinRange;
			}
			else if (bmi.BMI < 22.5)
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
				rangeForSpeed = new Range<Rating>(rangeForSpeed.Lower * 0.8, rangeForSpeed.Upper * 0.9);
			}
			else if (age < PersonAge.FromYears(23))
			{
				rangeForSpeed = new Range<Rating>(rangeForSpeed.Lower * 1.05, rangeForSpeed.Upper * 1.05);
			}
			return new GenRange(FeatureType.TopSpeed, rangeForSpeed);
		}
	}
}
