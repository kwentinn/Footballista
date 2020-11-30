using Footballista.BuildingBlocks.Domain;
using Footballista.Game.Domain.Players.Features;
using Footballista.Game.Domain.Players.Physique;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Footballista.Players.Features.LinkedFeatures
{
	public sealed record TopSpeedFeature : PhysicalFeature
	{
		private record RatingForBmiRule(Range<double> Range, Rating MaxRating);

		private BodyMassIndex _bmi;

		private readonly List<RatingForBmiRule> _ratingForBmiRules = new List<RatingForBmiRule>
		{
			new RatingForBmiRule(new Range<double>(10, 21.49), new Rating(0.85)),
			new RatingForBmiRule(new Range<double>(21.5, 22.99), Rating.Max),
			new RatingForBmiRule(new Range<double>(23, 30), new Rating(0.7))
		};

		public TopSpeedFeature(BodyMassIndex bmi = null, Rating rating = null)
			: base(FeatureType.TopSpeed, rating)
		{
			_bmi = bmi;
		}

		public new void ChangeRating(Rating newRating)
		{
			if (_bmi is null)
			{
				throw new InvalidOperationException("Bmi must be set before calling ChangeRating(Rating newRating)");
			}
			// règles en fonction du BMI ///
			// - on doit plutôt modifier le rating sans forcément lancer une exception
			// car ce n'est pas une saisie utilisateur
			// ==> on doit plutôt définir des valeurs max en fonction du BMI.
			// ou alors un pourcentage 
			// la règle :
			// plus un joueur est léger, plus il peut atteindre une vitesse max importante
			// |<---- trop léger --->|<--- poids idéal --->|<--- trop lourd --->|
			// |        vmax=80%     |       vmax=100%     |      vmax=70%		|

			RatingForBmiRule ratingRule = _ratingForBmiRules
				.FirstOrDefault(r => r.Range.IsValueInRange(_bmi.BMI));
			if (ratingRule is null)
			{
				throw new InvalidOperationException("Player's bmi must be within range 10-30.");
			}

			Rating = (newRating > ratingRule.MaxRating) ? ratingRule.MaxRating : newRating;
		}
		public void ChangeRating(BodyMassIndex bmi, Rating newRating)
		{
			_bmi = bmi;

			ChangeRating(newRating);
		}
	}
}
