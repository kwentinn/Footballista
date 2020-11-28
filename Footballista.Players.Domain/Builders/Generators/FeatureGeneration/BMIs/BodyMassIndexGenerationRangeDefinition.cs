using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Players.Domain.Builders.Generators.FeatureGeneration;
using Footballista.Players.Domain.Physique;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Footballista.Players.Builders.Generators.FeatureGeneration
{
	public class BodyMassIndexGenerationRangeDefinition
	{
		public static ReadOnlyCollection<GenRange> Generate(BodyMassIndex bmi, PersonAge age)
		{
			var list = new List<GenRange>();

			list.Add(new BmiRangeForPowerCalculator().Calculate(bmi, age));
			list.Add(new BmiRangeForHeaderCalculator().Calculate(bmi, age));
			list.Add(new BmiRangeForSpeedCalculator().Calculate(bmi, age));
			list.Add(new BmiRangeForAccelerationCalculator().Calculate(bmi, age));

			return list.AsReadOnly();
		}
	}
}
