using Footballista.BuildingBlocks.Domain;
using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Game.Domain.Players.Builders.Generators.FeatureGeneration;
using Footballista.Game.Domain.Players.Features;
using Footballista.Game.Domain.Players.Physique;
using UnitsNet;
using UnitsNet.Units;

namespace Footballista.Players.Builders.Generators.FeatureGeneration
{
	public class BmiRangeForHeaderCalculator : GenRangeCalculator
	{
		private readonly Length _minimuHeightForMaxRange = new Length(180, LengthUnit.Centimeter);
		private readonly Length _minimuHeightForMinRange = new Length(165, LengthUnit.Centimeter);

		private BodyMassIndex _bmi;

		public BmiRangeForHeaderCalculator ForBmi(BodyMassIndex bmi)
		{
			_bmi = bmi;
			return this;
		}

		public override GenRange Calculate()
		{
			if (_bmi.Height >= _minimuHeightForMaxRange)
			{
				return new GenRange(FeatureType.Header, MaxRange);
			}

			if (_bmi.Height < _minimuHeightForMinRange)
			{
				return new GenRange(FeatureType.Header, MinRange);
			}

			return new GenRange(FeatureType.Header, MediumRange);
		}
	}
}
