using Footballista.BuildingBlocks.Domain;
using Footballista.Players.Features;
using Footballista.Players.Physique;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Footballista.Players.Builders.Generators.FeatureGeneration
{
	public class BodyMassIndexGenerationRangeDefinition
	{
		protected static Range<Rating> MinRange = new Range<Rating>(Rating.FromInt(20), Rating.FromInt(40));
		protected static Range<Rating> MediumRange = new Range<Rating>(Rating.FromInt(35), Rating.FromInt(55));
		protected static Range<Rating> MaxRange = new Range<Rating>(Rating.FromInt(50), Rating.FromInt(80));
		
		public static ReadOnlyCollection<GenRange> Generate(BodyMassIndex bmi, PersonAge age)
		{
			return new List<GenRange>
			{
				// higher BMI means more power, but less acceleration
				new GenRange(Feature.Power, GetRangeForPower(bmi, age)),
				
				// taller players have better heading capabilities
				new GenRange(Feature.Header, GetRangeForHeader(bmi)),

				// handle top speed and acceleration
				new GenRange(Feature.TopSpeed, GetRangeForSpeed(bmi, age)),
				new GenRange(Feature.Acceleration, GetRangeForSpeed(bmi, age)),
			}
			.AsReadOnly();
		}

		private static Range<Rating> GetRangeForPower(BodyMassIndex bmi, PersonAge age)
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

			// take player age into account
			if (age.Years > 25)
			{
				rangeForPower = new Range<Rating>
				(
					new Rating(rangeForPower.Lower.Value * 1.05),
					new Rating(rangeForPower.Upper.Value * 1.05)
				);
			}
			else if (age.Years < 20)
			{
				rangeForPower = new Range<Rating>
				(
					new Rating(rangeForPower.Lower.Value * 0.8),
					new Rating(rangeForPower.Upper.Value * 0.9)
				);
			}

			return rangeForPower;
		}
		private static Range<Rating> GetRangeForHeader(BodyMassIndex bmi)
		{
			Range<Rating> rangeForHeader;
			if (bmi.Height.Centimeters >= 180)
			{
				rangeForHeader = MaxRange;
			}
			else if (bmi.Height.Centimeters < 165)
			{
				rangeForHeader = MinRange;
			}
			else
			{
				rangeForHeader = MediumRange;
			}
			return rangeForHeader;
		}
		private static Range<Rating> GetRangeForSpeed(BodyMassIndex bmi, PersonAge age)
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
			if (age.Years > 30)
			{
				rangeForSpeed = new Range<Rating>
				(
					new Rating(rangeForSpeed.Lower.Value * 0.8),
					new Rating(rangeForSpeed.Upper.Value * 0.9)
				);
			}
			else if (age.Years < 23)
			{
				rangeForSpeed = new Range<Rating>
				(
					new Rating(rangeForSpeed.Lower.Value * 1.05),
					new Rating(rangeForSpeed.Upper.Value * 1.05)
				);
			}

			return rangeForSpeed;
		}
	}
}
