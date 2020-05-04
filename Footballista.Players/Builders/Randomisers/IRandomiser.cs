using Footballista.Players.Features;
using System;

namespace Footballista.Players.Builders.Randomisers
{
	public interface IRandomiser<T>
	{
		T Randomise();
		T Randomise(T min, T max);
	}
	public abstract class GenericRandomiser
	{
		protected readonly Random Random = new Random();
	}
	public class IntRandomiser : GenericRandomiser, IRandomiser<int>
	{
		public int Randomise() => Random.Next(0, int.MaxValue);
		public int Randomise(int min, int max) => Random.Next(min, max);
	}
	public class AgeRandomiser : GenericRandomiser, IRandomiser<Age>
	{
		public Age Randomise()
			=> Age.FromDays(Random.Next(Convert.ToInt32(Age.Min.Days), Convert.ToInt32(Age.Max.Days)));
		public Age Randomise(Age min, Age max)
			=> Age.FromDays(Random.Next(Convert.ToInt32(min.Days), Convert.ToInt32(max.Days)));
	}
	public class FeatureRatingRandomiser : GenericRandomiser, IRandomiser<FeatureRating>
	{
		public FeatureRating Randomise() => Randomise(FeatureRating.Min, FeatureRating.Max);

		public FeatureRating Randomise(FeatureRating min, FeatureRating max)
		{
			int minValue = Convert.ToInt32(Math.Round(min.Rating * 100d, 0));
			int maxValue = Convert.ToInt32(Math.Round(max.Rating * 100d, 0));

			double value = Convert.ToDouble(Random.Next(minValue, maxValue)) / 100d;

			return new FeatureRating(value);
		}
	}
}
