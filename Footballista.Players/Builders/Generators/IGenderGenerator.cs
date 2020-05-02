using Footballista.Players.Persons;
using System;

namespace Footballista.Players.Builders.Generators
{
	public interface IGenderGenerator
	{
		Gender Generate();
	}
	public class GenderGenerator : IGenderGenerator
	{
		private Random _random = new Random();

		public Gender Generate()
		{
			return (Gender)_random.Next(1, 3);
		}
	}
}
