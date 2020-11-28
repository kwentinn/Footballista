using Footballista.BuildingBlocks.Domain;
using Footballista.Players.Domain.Features;

namespace Footballista.Players.Domain.Builders.Generators.FeatureGeneration
{
	/// <summary>
	/// Représente une plage de génération de note d'une caractéristique de joueur.
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
