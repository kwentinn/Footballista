using Footballista.BuildingBlocks.Domain;
using System;

namespace Footballista.Players.Builders.Randomisers
{
	public class AgeRandomiser : IRandomiser<PersonAge>
	{
		private readonly IRandomiser<int> _intRandomiser;

		private static int MinDays => Convert.ToInt32(PersonAge.Min.Days);
		private static int MaxDays => Convert.ToInt32(PersonAge.Max.Days);

		public AgeRandomiser(IRandomiser<int> intRandomiser)
		{
			_intRandomiser = intRandomiser;
		}

		public PersonAge Randomise()
			=> PersonAge.FromDays(_intRandomiser.Randomise(MinDays, MaxDays));
		public PersonAge Randomise(PersonAge min, PersonAge max)
			=> PersonAge.FromDays(_intRandomiser.Randomise(Convert.ToInt32(min.Days), Convert.ToInt32(max.Days)));

		public PersonAge Randomise(Range<PersonAge> range)
			=> Randomise(range.Lower, range.Upper);
	}
}
