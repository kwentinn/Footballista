using Footballista.BuildingBlocks.Domain;
using MathNet.Numerics.Random;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Footballista.Players.Builders.Randomisers
{
    public class MultipleIntValuesRandomiser : IMultipleValuesRandomiser<int>
    {
        private readonly IEnumerable<double> values = SystemRandomSource.DoubleSequence();
        private IEnumerator<double> enumerator;
        private readonly object @lock = new object();

        public MultipleIntValuesRandomiser()
        {
        }

        public IEnumerable<int> RandomiseDistinctValues(Range<int> intRange, int numberOfItemsToGenerate)
        {
            int rangeSpan = intRange.Upper - intRange.Lower;
            if( rangeSpan < numberOfItemsToGenerate)
            {
                throw new InvalidOperationException("Cannot generate randomised values.");
            }

            List<int> allValues = new List<int>(rangeSpan);
            for (int i = intRange.Lower; i < intRange.Upper; i++)
            {
                allValues.Add(i);
            }
            var randomInts = new List<int>();
            for (int i = 0; i < numberOfItemsToGenerate; i++)
            {
                int randomisedIndex = GetRandomisedInt(allValues.Count - 1);
                var randomInt = allValues[randomisedIndex];
                randomInts.Add(randomInt);
                allValues.RemoveAt(randomisedIndex);
            }
            return randomInts;
        }
        private int GetRandomisedInt(int max)
        {
            this.enumerator ??= this.values.GetEnumerator();
            this.enumerator.MoveNext();
            var randomisedDouble = this.enumerator.Current;
            return Convert.ToInt32(randomisedDouble * max);
        }

        public int[] GetRandomisedValues(Range<int> intRange, int numberOfItemsToGenerate, bool allowIdenticalValues = false)
        {
            List<int> randomisedValues = new List<int>();
            foreach (double @double in this.GetCurrentValues(numberOfItemsToGenerate))
            {
                int value = GetValueFromDouble(intRange, @double);
                if (!allowIdenticalValues)
                {
                    const int maxIterations = 3;
                    for (int i = 0; randomisedValues.Contains(value) && i < maxIterations; i++)
                    {
                        double d = this.GetRandomisedValue();
                        value = GetValueFromDouble(intRange, d);
                    }
                }
                randomisedValues.Add(value);
            }
            return randomisedValues.ToArray();
        }

        private IEnumerable<double> GetCurrentValues(int numberOfItems)
        {
            lock (this.@lock)
            {
                List<double> items = new List<double>();
                this.enumerator ??= this.values.GetEnumerator();
                for (int i = 0; i < numberOfItems; i++)
                {
                    this.enumerator.MoveNext();
                    yield return this.enumerator.Current;
                }
            }
        }
        private double GetRandomisedValue()
        {
            this.enumerator ??= this.values.GetEnumerator();
            this.enumerator.MoveNext();
            return this.enumerator.Current;
        }

        private static int GetValueFromDouble(Range<int> intRange, double dbl)
        {
            int range = intRange.Upper - intRange.Lower;
            return Convert.ToInt32(dbl * range) + intRange.Lower;
        }
    }
}
