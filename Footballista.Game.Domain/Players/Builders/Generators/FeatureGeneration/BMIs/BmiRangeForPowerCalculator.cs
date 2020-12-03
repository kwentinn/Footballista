using Footballista.BuildingBlocks.Domain;
using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Game.Domain.Players.Builders.Generators.FeatureGeneration;
using Footballista.Game.Domain.Players.Features;
using Footballista.Game.Domain.Players.Physique;

namespace Footballista.Players.Builders.Generators.FeatureGeneration
{
	public class BmiRangeForPowerCalculator : GenRangeCalculator
	{
		private BodyMassIndex _bmi;
		private PersonAge _age;

		public BmiRangeForPowerCalculator ForBmi(BodyMassIndex bmi)
		{
			_bmi = bmi;
			return this;
		}
		public BmiRangeForPowerCalculator ForAge(PersonAge age)
		{
			_age = age;
			return this;
		}

		public override GenRange Calculate()
		{
			Range<Rating> rangeForPower;
			if (_bmi.BMI > 23 && _bmi.Height.Centimeters >= 185)
			{
				rangeForPower = MaxRange;
			}
			else if (_bmi.BMI < 22)
			{
				rangeForPower = MinRange;
			}
			else
			{
				rangeForPower = MediumRange;
			}

			// take player's age into account
			if (_age > PersonAge.FromYears(25))
			{
				rangeForPower = new Range<Rating>(rangeForPower.Lower * 1.05, rangeForPower.Upper * 1.05);
			}
			else if (_age < PersonAge.FromYears(20))
			{
				rangeForPower = new Range<Rating>(rangeForPower.Lower * 0.8, rangeForPower.Upper * 0.9);
			}
			return new GenRange(FeatureType.Power, rangeForPower);
		}
	}
}
