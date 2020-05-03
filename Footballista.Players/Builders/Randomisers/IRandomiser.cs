using System;
using System.Collections.Generic;
using System.Text;

namespace Footballista.Players.Builders.Randomisers
{
	public interface IRandomiser<T>
	{
		T Randomise(T min, T max);
	}
	public class IntRandomiser : IRandomiser<int>
	{
		private readonly Random _random = new Random();
		public int Randomise(int min, int max) =>_random.Next(min, max);
	}
	public class AgeRandomiser : IRandomiser<Age>
	{
		private readonly Random _random = new Random();
		public Age Randomise(Age min, Age max) 
			=> Age.FromDays(_random.Next(Convert.ToInt32(min.Days), Convert.ToInt32(max.Days)));
	}
}
