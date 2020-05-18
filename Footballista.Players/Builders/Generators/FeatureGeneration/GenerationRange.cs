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
		public Feature Feature { get; }
		public Range<Rating> RatingRange { get; }

		public GenRange(Feature feature, Range<Rating> ratingRange)
		{
			Feature = feature;
			RatingRange = ratingRange;
		}
	}
}
