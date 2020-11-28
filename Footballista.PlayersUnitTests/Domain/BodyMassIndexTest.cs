using Footballista.BuildingBlocks.Domain;
using Footballista.Players.Domain.Physique;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitsNet;
using UnitsNet.Units;

namespace Footballista.PlayersUnitTests.Domain
{
	[TestClass]
	public class BodyMassIndexTest
	{
		[TestMethod]
		public void New_PassHeightOfZeroCentimeters_ShouldThrowBusinessRuleValidationException()
		{
			Assert.ThrowsException<BusinessRuleValidationException>(() =>
			{
				var bmi = new BodyMassIndex(new Length(), new Mass(50, MassUnit.Kilogram));
			});
		}
		[TestMethod]
		public void New_PassWeightOfZeroKilograms_ShouldThrowBusinessRuleValidationException()
		{
			Assert.ThrowsException<BusinessRuleValidationException>(() =>
			{
				var bmi = new BodyMassIndex(new Length(1, LengthUnit.Meter), new Mass());
			});
		}
		[TestMethod]
		public void New_PassValidValues_ShouldReturnNewBmi()
		{
			BodyMassIndex bmi = new BodyMassIndex(new Length(1.5, LengthUnit.Meter), new Mass(50, MassUnit.Kilogram));

			Assert.IsNotNull(bmi);
		}
		[TestMethod]
		public void New_PassValidValues_ShouldReturnNewBmiWithObeseRange()
		{
			BodyMassIndex bmi = new BodyMassIndex(new Length(2, LengthUnit.Meter), new Mass(130, MassUnit.Kilogram));

			Assert.IsNotNull(bmi);
			Assert.AreEqual(BmiType.Obese, bmi.BmiType);
			Assert.IsNotNull(bmi.BmiRange);
			Assert.AreEqual(BodyMassIndex.Obese, bmi.BmiRange);
		}
		[TestMethod]
		public void New_PassValidValues_ShouldReturnNewBmiWithUnderweightRange()
		{
			BodyMassIndex bmi = new BodyMassIndex(new Length(2, LengthUnit.Meter), new Mass(60, MassUnit.Kilogram));

			Assert.IsNotNull(bmi);
			Assert.IsNotNull(bmi.BmiRange);
			Assert.AreEqual(BodyMassIndex.Underweight, bmi.BmiRange);
			Assert.AreEqual(BmiType.Underweight, bmi.BmiType);
		}
	}
}
