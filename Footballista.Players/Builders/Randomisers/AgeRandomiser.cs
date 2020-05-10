using Footballista.BuildingBlocks.Domain;
using System;

namespace Footballista.Players.Builders.Randomisers
{
	public class AgeRandomiser : GenericRandomiser, IRandomiser<PersonAge>
	{
		public PersonAge Randomise()
			=> PersonAge.FromDays(Random.Next(Convert.ToInt32(PersonAge.Min.Days), Convert.ToInt32(PersonAge.Max.Days)));
		public PersonAge Randomise(PersonAge min, PersonAge max)
			=> PersonAge.FromDays(Random.Next(Convert.ToInt32(min.Days), Convert.ToInt32(max.Days)));

		public PersonAge Randomise(Range<PersonAge> range)
			=> Randomise(range.Min, range.Max);
	}
}
