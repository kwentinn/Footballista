using System;
using System.Collections.Generic;
using System.Linq;

namespace Footballista.Players.Builders.Randomisers
{
	public interface IListRandomiser
	{
		T GetRandomisedItem<T>(List<T> list) where T : class;
		T GetRandomisedItem<T>(List<T> list, Func<T, bool> filterPredicate) where T : class;
		T[] GetRandomisedItems<T>(List<T> list, int nbOfItemsToReturn) where T : class;
		T[] GetRandomisedItems<T>(List<T> list, Func<T, bool> filterPredicate, int nbOfItemsToReturn) where T : class;
	}
	public class ListRandomiser : IListRandomiser
	{
		private readonly IRandomiser<int> _intRandomiser;

		public ListRandomiser(IRandomiser<int> intRandomiser)
		{
			this._intRandomiser = intRandomiser;
		}

		public T GetRandomisedItem<T>(List<T> list)
			where T : class
		{
			if (list is null) throw new ArgumentNullException(nameof(list));
			if (!list.Any()) throw new ArgumentException(nameof(list));

			int nbOfItems = list.Count;
			return list.ElementAt(_intRandomiser.Randomise(0, nbOfItems));
		}
		public T GetRandomisedItem<T>(List<T> list, Func<T, bool> filterPredicate) where T : class
		{
			if (list is null) throw new ArgumentNullException(nameof(list));
			if (filterPredicate == null) throw new ArgumentException(nameof(filterPredicate));

			int nbOfItems = list.Count(filterPredicate);
			return list.Where(filterPredicate).ElementAt(_intRandomiser.Randomise(0, nbOfItems));
		}
		public T[] GetRandomisedItems<T>(List<T> list, int nbOfItemsToReturn) where T : class
		{
			if (list is null) throw new ArgumentNullException(nameof(list));
			if (nbOfItemsToReturn <= 0) throw new ArgumentException(nameof(nbOfItemsToReturn));

			var returnList = new List<T>();
			for (int i = 0; i < nbOfItemsToReturn; i++)
			{
				int nbOfItems = list.Count;
				T item = list.ElementAt(_intRandomiser.Randomise(0, nbOfItems));
				returnList.Add(item);
			}
			return returnList.ToArray();
		}
		public T[] GetRandomisedItems<T>(List<T> list, Func<T, bool> filterPredicate, int nbOfItemsToReturn) where T : class
		{
			if (list is null) throw new ArgumentNullException(nameof(list));
			if (filterPredicate == null) throw new ArgumentException(nameof(filterPredicate));
			if (nbOfItemsToReturn <= 0) throw new ArgumentException(nameof(nbOfItemsToReturn));

			var returnList = new List<T>();
			for (int i = 0; i < nbOfItemsToReturn; i++)
			{
				int nbOfItems = list.Count(filterPredicate);
				var item = list.Where(filterPredicate).ElementAt(_intRandomiser.Randomise(0, nbOfItems));
				returnList.Add(item);
			}
			return returnList.ToArray();
		}
	}
}
