using Footballista.BuildingBlocks.Domain;
using Footballista.Players.Features;
using Footballista.Players.Positions;

namespace Footballista.Players.Builders.Generators.FeatureGeneration.PlayerPositions
{
	public class CentreBackGenerationRangeDefinition : PlayerPositionGenerationRangeDefinition
	{
		internal CentreBackGenerationRangeDefinition(PlayerPosition position) : base(position)
		{
			generationRanges.AddRange(new GenRange[]
			{
				// top skills
				new GenRange(Feature.Acceleration, new Range<Rating>(Rating.FromInt(40), Rating.FromInt(70))),
				new GenRange(Feature.TopSpeed, new Range<Rating>(Rating.FromInt(50), Rating.FromInt(70))),
				new GenRange(Feature.Finishing, new Range<Rating>(Rating.FromInt(50), Rating.FromInt(70))),
				
				// medium skills
				new GenRange(Feature.PassingAccuracy, new Range<Rating>(Rating.FromInt(40), Rating.FromInt(60))),
				new GenRange(Feature.PassingSpeed, new Range<Rating>(Rating.FromInt(40), Rating.FromInt(60))),
				new GenRange(Feature.Cross, new Range<Rating>(Rating.FromInt(40), Rating.FromInt(60))),

				// bad skills
				new GenRange(Feature.Interception, new Range<Rating>(Rating.FromInt(10), Rating.FromInt(30))),
				new GenRange(Feature.Tackling, new Range<Rating>(Rating.FromInt(10), Rating.FromInt(30))),
			});
		}
	}
}