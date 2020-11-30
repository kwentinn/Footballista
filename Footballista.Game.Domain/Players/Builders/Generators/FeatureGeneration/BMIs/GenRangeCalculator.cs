using Footballista.BuildingBlocks.Domain;
using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Game.Domain.Players.Builders.Generators.FeatureGeneration;
using Footballista.Game.Domain.Players.Features;
using Footballista.Game.Domain.Players.Physique;

namespace Footballista.Players.Builders.Generators.FeatureGeneration
{
	public abstract class GenRangeCalculator
	{
		protected static Range<Rating> MinRange = new Range<Rating>(Rating.FromInt(20), Rating.FromInt(40));
		protected static Range<Rating> MediumRange = new Range<Rating>(Rating.FromInt(35), Rating.FromInt(55));
		protected static Range<Rating> MaxRange = new Range<Rating>(Rating.FromInt(50), Rating.FromInt(80));

		public abstract GenRange Calculate(BodyMassIndex bmi, PersonAge age);
	}
}
