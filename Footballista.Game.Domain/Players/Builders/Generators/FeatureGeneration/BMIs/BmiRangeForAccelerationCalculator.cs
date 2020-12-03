using Footballista.BuildingBlocks.Domain;
using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Game.Domain.Players.Builders.Generators.FeatureGeneration;
using Footballista.Game.Domain.Players.Features;
using Footballista.Game.Domain.Players.Physique;

namespace Footballista.Players.Builders.Generators.FeatureGeneration
{
	public class BmiRangeForAccelerationCalculator : GenRangeCalculator
	{
		private BodyMassIndex _bmi;
		private PersonAge _age;

		public BmiRangeForAccelerationCalculator ForBmi(BodyMassIndex bmi)
		{
			_bmi = bmi;
			return this;
		}
		public BmiRangeForAccelerationCalculator ForAge(PersonAge age)
		{
			_age = age;
			return this;
		}

		public override GenRange Calculate()
		{
			Range<Rating> rangeForSpeed;
			if (_bmi.BMI > 22.8)
			{
				rangeForSpeed = MinRange;
			}
			else if (_bmi.BMI < 21.2)
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
				rangeForSpeed = new Range<Rating>(rangeForSpeed.Lower * 0.82, rangeForSpeed.Upper * 0.88);
			}
			else if (_age < PersonAge.FromYears(23))
			{
				rangeForSpeed = new Range<Rating>(rangeForSpeed.Lower * 1.052, rangeForSpeed.Upper * 1.055);
			}
			return new GenRange(FeatureType.Acceleration, rangeForSpeed);
		}
	}
}
