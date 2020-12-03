using Footballista.BuildingBlocks.Domain;
using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Game.Domain.Players.Builders.Generators.FeatureGeneration;
using Footballista.Game.Domain.Players.Features;
using Footballista.Game.Domain.Players.Physique;

namespace Footballista.Players.Builders.Generators.FeatureGeneration
{
	public class BmiRangeForSpeedCalculator : GenRangeCalculator
	{
		private BodyMassIndex _bmi;
		private PersonAge _age;

		public BmiRangeForSpeedCalculator ForBmi(BodyMassIndex bmi)
		{
			_bmi = bmi;
			return this;
		}
		public BmiRangeForSpeedCalculator ForAge(PersonAge age)
		{
			_age = age;
			return this;
		}

		public override GenRange Calculate()
		{
			Range<Rating> rangeForSpeed;
			if (_bmi.BMI > 23.5)
			{
				rangeForSpeed = MinRange;
			}
			else if (_bmi.BMI < 22.5)
			{
				rangeForSpeed = MaxRange;
			}
			else
			{
				rangeForSpeed = MediumRange;
			}

			// take player age into account
			if (_age > PersonAge.FromYears(30))
			{
				rangeForSpeed = new Range<Rating>(rangeForSpeed.Lower * 0.8, rangeForSpeed.Upper * 0.9);
			}
			else if (_age < PersonAge.FromYears(23))
			{
				rangeForSpeed = new Range<Rating>(rangeForSpeed.Lower * 1.05, rangeForSpeed.Upper * 1.05);
			}
			return new GenRange(FeatureType.TopSpeed, rangeForSpeed);
		}
	}
}
