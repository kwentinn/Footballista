using Footballista.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnitsNet;

namespace Footballista.Players.Physique
{
    [DebuggerDisplay("{Height.Centimeters}cm, {Weight.Kilograms}kg ({BMI} - {BmiType})")]
    public record BodyMassIndex : ValueObjectRecord
    {
        public Length Height { get; }
        public Mass Weight { get; }

        public double BMI => Calculate();

        public BmiRange BmiRange => _bmiRanges.FirstOrDefault(br => br.Range.IsValueInRange(BMI));
        public BmiType BmiType => BmiRange.BmiType;

        public static BmiRange Underweight => new BmiRange(BmiType.Underweight, new Range<double>(0, 18.49));
        public static BmiRange Normalweight => new BmiRange(BmiType.NormalWeight, new Range<double>(18.5, 24.99));
        public static BmiRange Overweight => new BmiRange(BmiType.Overweight, new Range<double>(25, 29.99));
        public static BmiRange Obese => new BmiRange(BmiType.Obese, new Range<double>(30, 100));

        private static List<BmiRange> _bmiRanges = new List<BmiRange> { Underweight, Normalweight, Overweight, Obese };

        public BodyMassIndex(Length height, Mass weight)
        {
            CheckRule(new Rules.HeightMustBeWithinRangeRule(height));
            CheckRule(new Rules.WeightMustBeWithinRangeRule(weight));

            Height = height;
            Weight = weight;

            // BMI cannot be calculated while Height and Weight have not been set. 
            CheckRule(new Rules.BmiMustBeWithinRangeRule(BMI));
        }

        private double Calculate()
        {
            return Math.Round(Weight.Kilograms / Math.Pow(Height.Meters, 2), 2);
        }
    }
}
