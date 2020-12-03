using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Game.Domain.Players.Builders.Generators.FeatureGeneration;
using Footballista.Game.Domain.Players.Physique;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Footballista.Players.Builders.Generators.FeatureGeneration
{
	public static class BodyMassIndexGenerationRangeDefinition
	{
		public static ReadOnlyCollection<GenRange> Generate(BodyMassIndex bmi, PersonAge age)
		{
			return new List<GenRange>
			{
				new BmiRangeForPowerCalculator()
					.ForAge(age)
					.ForBmi(bmi)
					.Calculate(),

				new BmiRangeForHeaderCalculator()
					.ForBmi(bmi)
					.Calculate(),

				new BmiRangeForSpeedCalculator()
					.ForAge(age)
					.ForBmi(bmi)
					.Calculate(),

				new BmiRangeForAccelerationCalculator()
					.ForAge(age)
					.ForBmi(bmi)
					.Calculate()
			}.AsReadOnly();
		}
	}
}
