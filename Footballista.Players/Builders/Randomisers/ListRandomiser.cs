using System;
using System.Collections.Generic;
using System.Linq;

namespace Footballista.Players.Builders.Randomisers
{
	public interface IListRandomiser
	{
		T GetRandomisedItemFromList<T>(List<T> list) where T : class;
		T GetRandomisedItemFromList<T>(List<T> list, Func<T, bool> filterPredicate) where T : class;
	}
	public class ListRandomiser : IListRandomiser
	{
		private readonly Random _random = new Random();

		public T GetRandomisedItemFromList<T>(List<T> list)
			where T : class
		{
			if (list is null) throw new ArgumentNullException(nameof(list));

			int nbOfItems = list.Count;
			return list.ElementAt(_random.Next(nbOfItems));
		}
		public T GetRandomisedItemFromList<T>(List<T> list, Func<T, bool> filterPredicate) where T : class
		{
			if (list is null) throw new ArgumentNullException(nameof(list));
			if (filterPredicate == null) throw new ArgumentException(nameof(filterPredicate));

			int nbOfItems = list.Count(filterPredicate);
			return list.Where(filterPredicate).ElementAt(_random.Next(nbOfItems));
		}
	}
}
