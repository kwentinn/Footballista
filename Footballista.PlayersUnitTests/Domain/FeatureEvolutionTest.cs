﻿using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Players.Domain.Features;
using Footballista.Players.Domain.PlayerEvolutions;
using Footballista.Players.PlayerEvolutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Footballista.PlayersUnitTests.Domain
{
	[TestClass]
	public class FeatureEvolutionTest
	{
		[TestMethod]
		public void Phase1Evolution_GetValue()
		{
			FeatureImprovementRatio improvement = Phase1Evolution.Value.GetImprovementFromAge(PersonAge.FromYears(16));

			Assert.IsNotNull(improvement);
			Assert.AreEqual(0.01, improvement);
		}
		[TestMethod]
		public void GetValue_Pass28_ShouldReturnValue()
		{
			FeatureImprovementRatio improvement = Phase1Evolution.Value.GetImprovementFromAge(PersonAge.FromYears(28));

			Assert.IsNotNull(improvement);
			Assert.AreEqual(0.5, improvement);
		}
		[TestMethod]
		public void Phase1Evolution_ImproveRating()
		{
			FeatureImprovementRatio improvement = Phase1Evolution.Value.GetImprovementFromAge(PersonAge.FromYears(16));

			Rating rating = new Rating(0.2);
			var newRating = improvement.ImproveRating(rating);

			Assert.IsNotNull(newRating);
			Assert.AreEqual(0.2, newRating);

		}
		[TestMethod]
		public void Phase1Evolution_ImproveRating2()
		{
			FeatureImprovementRatio improvement = Phase1Evolution.Value.GetImprovementFromAge(PersonAge.FromYears(28));

			Rating rating = new Rating(0.2);
			var newRating = improvement.ImproveRating(rating);

			Assert.IsNotNull(newRating);
			Assert.AreEqual(0.3, newRating);

		}
		[TestMethod]
		public void Phase1Evolution_ImproveRating3()
		{
			FeatureImprovementRatio improvement = Phase1Evolution.Value.GetImprovementFromAge(PersonAge.FromYears(28));

			Rating rating = new Rating(0.45);
			var newRating = improvement.ImproveRating(rating);

			Assert.IsNotNull(newRating);
			Assert.AreEqual(0.68, newRating);
		}
		[TestMethod]
		public void Phase1Evolution_ImproveRating4()
		{
			FeatureImprovementRatio improvement = Phase1Evolution.Value.GetImprovementFromAge(PersonAge.FromYears(28));

			Rating rating = new Rating(0.7);
			Rating newRating = improvement.ImproveRating(rating);

			Assert.IsNotNull(newRating);
			Assert.AreEqual(0.99, newRating);
		}
		[TestMethod]
		public void ImproveRatingFromAge_()
		{
			Rating rating = new Rating(0.6);
			AgeRating ageRating = new AgeRating(PersonAge.FromYears(27), rating);
			AgeRating newRatingForAge = Phase1Evolution.Value.ImproveRatingFromAge(ageRating, Duration.FromYears(1));

			Assert.IsNotNull(newRatingForAge);
			Assert.AreEqual(28d, newRatingForAge.Age.Years);
			Assert.AreEqual(0.64, newRatingForAge.Rating);
		}
		[TestMethod]
		public void ImproveRatingFromAge_2()
		{
			Rating rating = new Rating(0.8);
			AgeRating ageRating = new AgeRating(PersonAge.FromYears(27), rating);
			AgeRating newRatingForAge = Phase1Evolution.Value.ImproveRatingFromAge(ageRating, Duration.FromMonths(1));

			Assert.IsNotNull(newRatingForAge);
			Assert.AreEqual(Duration.FromMonths(27 * 12 + 1).Years, newRatingForAge.Age.Years);
			Assert.AreEqual(0.81, newRatingForAge.Rating);
		}
	}
}
