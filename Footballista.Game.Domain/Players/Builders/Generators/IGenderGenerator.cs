using Footballista.Players.Builders.Randomisers;
using Footballista.Game.Domain.Players.Persons;
using System;

namespace Footballista.Players.Builders.Generators
{
	public interface IGenderGenerator
	{
		Gender Generate();
	}
	public class GenderGenerator : IGenderGenerator
	{
		private readonly IRandomiser<int> _intRandomiser;

		public GenderGenerator(IRandomiser<int> intRandomiser)
		{
			_intRandomiser = intRandomiser;
		}

		public Gender Generate()
		{
			return (Gender)_intRandomiser.Randomise(1, 2);
		}
	}
}
