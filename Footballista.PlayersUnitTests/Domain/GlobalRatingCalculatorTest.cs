using Footballista.Players.Features;
using Footballista.Players.Features.GlobalRatingCalculators;
using Footballista.Players.Positions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Footballista.PlayersUnitTests.Domain
{
	[TestClass]
	public class GlobalRatingCalculatorTest
	{
		[TestMethod]
		public void Calculate_PassCentreForwardAndValidSet_ShouldReturn50PctRating()
		{
			// arrange
			GlobalRatingCalculator grc = new GlobalRatingCalculator();
			PhysicalFeatureSet set = PhysicalFeatureSet.ForwardFeatureSet;
			foreach (PhysicalFeature feat in set.PhysicalFeatures)
			{
				feat.ChangeRating(Rating.FromInt(50));
			}

			// act
			Rating generalRating = grc.Calculate(PlayerPosition.CentreForward, set);

			// assert
			Assert.IsNotNull(generalRating);
			Assert.AreEqual(Rating.FromInt(50), generalRating);
		}
		[TestMethod]
		public void Calculate_PassCentreForwardAndValidSet_ShouldReturn90PctRating()
		{
			// arrange
			GlobalRatingCalculator grc = new GlobalRatingCalculator();
			PhysicalFeatureSet set = PhysicalFeatureSet.ForwardFeatureSet;
			foreach (PhysicalFeature feat in set.PhysicalFeatures)
			{
				feat.ChangeRating(Rating.FromInt(90));
			}

			// act
			Rating generalRating = grc.Calculate(PlayerPosition.CentreForward, set);

			// assert
			Assert.IsNotNull(generalRating);
			Assert.AreEqual(Rating.FromInt(90), generalRating);
		}
		[TestMethod]
		public void Calculate_PassCentreForwardAndValidSet_ShouldReturnRatingOf96()
		{
			// arrange
			GlobalRatingCalculator grc = new GlobalRatingCalculator();
			PhysicalFeatureSet set = PhysicalFeatureSet.ForwardFeatureSet;


			set.PhysicalFeatures.Single(f => f.FeatureType == FeatureType.Finishing).ChangeRating(Rating.Max);
			set.PhysicalFeatures.Single(f => f.FeatureType == FeatureType.Header).ChangeRating(Rating.Max);
			set.PhysicalFeatures.Single(f => f.FeatureType == FeatureType.Power).ChangeRating(Rating.Max);
			set.PhysicalFeatures.Single(f => f.FeatureType == FeatureType.Composure).ChangeRating(Rating.Max);
			set.PhysicalFeatures.Single(f => f.FeatureType == FeatureType.ReactionSpeed).ChangeRating(Rating.Max);

			set.PhysicalFeatures.Single(f => f.FeatureType == FeatureType.Agility).ChangeRating(Rating.Max);
			set.PhysicalFeatures.Single(f => f.FeatureType == FeatureType.FightingSpirit).ChangeRating(Rating.Max);
			set.PhysicalFeatures.Single(f => f.FeatureType == FeatureType.Acceleration).ChangeRating(Rating.Max);
			set.PhysicalFeatures.Single(f => f.FeatureType == FeatureType.Focus).ChangeRating(Rating.Max);
			set.PhysicalFeatures.Single(f => f.FeatureType == FeatureType.PenaltyKick).ChangeRating(Rating.Max);

			set.PhysicalFeatures.Single(f => f.FeatureType == FeatureType.Morale).ChangeRating(Rating.Max);
			set.PhysicalFeatures.Single(f => f.FeatureType == FeatureType.Stamina).ChangeRating(Rating.Max);
			set.PhysicalFeatures.Single(f => f.FeatureType == FeatureType.TopSpeed).ChangeRating(Rating.Max);
			set.PhysicalFeatures.Single(f => f.FeatureType == FeatureType.Vista).ChangeRating(Rating.Max);

			set.PhysicalFeatures.Single(f => f.FeatureType == FeatureType.PassingSpeed).ChangeRating(Rating.FromInt(50));
			set.PhysicalFeatures.Single(f => f.FeatureType == FeatureType.FreeKick).ChangeRating(Rating.FromInt(50));
			set.PhysicalFeatures.Single(f => f.FeatureType == FeatureType.PassingAccuracy).ChangeRating(Rating.FromInt(50));
			set.PhysicalFeatures.Single(f => f.FeatureType == FeatureType.Cross).ChangeRating(Rating.FromInt(50));
			set.PhysicalFeatures.Single(f => f.FeatureType == FeatureType.Interception).ChangeRating(Rating.FromInt(50));
			set.PhysicalFeatures.Single(f => f.FeatureType == FeatureType.Tackling).ChangeRating(Rating.FromInt(50));




			// act
			Rating generalRating = grc.Calculate(PlayerPosition.CentreForward, set);

			// assert
			Assert.IsNotNull(generalRating);
			Assert.AreEqual(Rating.FromInt(96), generalRating);
		}
		[TestMethod]
		public void Calculate_PassCentreForwardAndValidSet_ShouldReturnRatingOf80()
		{
			// arrange
			GlobalRatingCalculator grc = new GlobalRatingCalculator();
			PhysicalFeatureSet set = PhysicalFeatureSet.ForwardFeatureSet;

			set.PhysicalFeatures.Single(f => f.FeatureType == FeatureType.Finishing).ChangeRating(Rating.Max);
			set.PhysicalFeatures.Single(f => f.FeatureType == FeatureType.Header).ChangeRating(Rating.Max);
			set.PhysicalFeatures.Single(f => f.FeatureType == FeatureType.Power).ChangeRating(Rating.Max);
			set.PhysicalFeatures.Single(f => f.FeatureType == FeatureType.Composure).ChangeRating(Rating.Max);
			set.PhysicalFeatures.Single(f => f.FeatureType == FeatureType.ReactionSpeed).ChangeRating(Rating.Max);

			set.PhysicalFeatures.Single(f => f.FeatureType == FeatureType.Agility).ChangeRating(Rating.FromInt(60));
			set.PhysicalFeatures.Single(f => f.FeatureType == FeatureType.FightingSpirit).ChangeRating(Rating.FromInt(60));
			set.PhysicalFeatures.Single(f => f.FeatureType == FeatureType.Acceleration).ChangeRating(Rating.FromInt(60));
			set.PhysicalFeatures.Single(f => f.FeatureType == FeatureType.Focus).ChangeRating(Rating.FromInt(60));
			set.PhysicalFeatures.Single(f => f.FeatureType == FeatureType.PenaltyKick).ChangeRating(Rating.FromInt(60));

			set.PhysicalFeatures.Single(f => f.FeatureType == FeatureType.Morale).ChangeRating(Rating.FromInt(60));
			set.PhysicalFeatures.Single(f => f.FeatureType == FeatureType.Stamina).ChangeRating(Rating.FromInt(60));
			set.PhysicalFeatures.Single(f => f.FeatureType == FeatureType.TopSpeed).ChangeRating(Rating.FromInt(60));
			set.PhysicalFeatures.Single(f => f.FeatureType == FeatureType.Vista).ChangeRating(Rating.FromInt(60));

			set.PhysicalFeatures.Single(f => f.FeatureType == FeatureType.PassingSpeed).ChangeRating(Rating.FromInt(50));
			set.PhysicalFeatures.Single(f => f.FeatureType == FeatureType.FreeKick).ChangeRating(Rating.FromInt(50));
			set.PhysicalFeatures.Single(f => f.FeatureType == FeatureType.PassingAccuracy).ChangeRating(Rating.FromInt(50));
			set.PhysicalFeatures.Single(f => f.FeatureType == FeatureType.Cross).ChangeRating(Rating.FromInt(50));
			set.PhysicalFeatures.Single(f => f.FeatureType == FeatureType.Interception).ChangeRating(Rating.FromInt(50));
			set.PhysicalFeatures.Single(f => f.FeatureType == FeatureType.Tackling).ChangeRating(Rating.FromInt(50));

			// act
			Rating generalRating = grc.Calculate(PlayerPosition.CentreForward, set);

			// assert
			Assert.IsNotNull(generalRating);
			Assert.AreEqual(Rating.FromInt(80), generalRating);
		}
	}
}
