using Footballista.BuildingBlocks.Domain;
using Footballista.Players.Features;

namespace Footballista.Players.Builders.Generators.FeatureGeneration
{
	/// <summary>
	/// Représente une plage de génération de note de caractéristique de joueur.
	/// </summary>
	public class GenRange
	{
		// telle feature => telle plage de génération
		public FeatureType FeatureType { get; }
		public Range<Rating> RatingRange { get; }

		public GenRange(FeatureType featureType, Range<Rating> ratingRange)
		{
			FeatureType = featureType;
			RatingRange = ratingRange;
		}
	}
}
