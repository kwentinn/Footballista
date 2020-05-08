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
	public class AgeRandomiser : GenericRandomiser, IRandomiser<PersonAge>
	{
		public PersonAge Randomise()
			=> PersonAge.FromDays(Random.Next(Convert.ToInt32(PersonAge.Min.Days), Convert.ToInt32(PersonAge.Max.Days)));
		public PersonAge Randomise(PersonAge min, PersonAge max)
			=> PersonAge.FromDays(Random.Next(Convert.ToInt32(min.Days), Convert.ToInt32(max.Days)));
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
