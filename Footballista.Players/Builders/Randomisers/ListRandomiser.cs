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
			_intRandomiser = intRandomiser;
		}

		public T GetRandomisedItem<T>(List<T> list) where T : class
		{
			if (list is null) throw new ArgumentNullException(nameof(list));
			if (!list.Any()) throw new ArgumentException(nameof(list));

			return GetRandomisedItemInternal(list);
		}
		public T GetRandomisedItem<T>(List<T> list, Func<T, bool> filterPredicate) where T : class
		{
			if (list is null) throw new ArgumentNullException(nameof(list));
			if (!list.Any()) throw new ArgumentException(nameof(list));
			if (filterPredicate == null) throw new ArgumentException(nameof(filterPredicate));

			return GetRandomisedItemInternal(list, filterPredicate);
		}

		private T GetRandomisedItemInternal<T>(List<T> list, Func<T, bool> filterPredicate = null) where T : class
		{
			if (list is null) throw new ArgumentNullException(nameof(list));

			int nbOfItems = filterPredicate != null ? list.Count(filterPredicate) : list.Count;
			int index = _intRandomiser.Randomise(0, nbOfItems);
			if (index >= nbOfItems)
			{
				index = nbOfItems - 1;
			}
			return filterPredicate != null ? list.Where(filterPredicate).ElementAt(index) : list.ElementAt(index);
		}


		public T[] GetRandomisedItems<T>(List<T> list, int nbOfItemsToReturn) where T : class
		{
			if (list is null) throw new ArgumentNullException(nameof(list));
			if (nbOfItemsToReturn <= 0) throw new ArgumentException(nameof(nbOfItemsToReturn));

			return GetRandomisedItemsInternal(list, nbOfItemsToReturn);
		}
		public T[] GetRandomisedItems<T>(List<T> list, Func<T, bool> filterPredicate, int nbOfItemsToReturn) where T : class
		{
			if (list is null) throw new ArgumentNullException(nameof(list));
			if (filterPredicate == null) throw new ArgumentException(nameof(filterPredicate));
			if (nbOfItemsToReturn <= 0) throw new ArgumentException(nameof(nbOfItemsToReturn));

			return GetRandomisedItemsInternal(list, nbOfItemsToReturn, filterPredicate);
		}
		private T[] GetRandomisedItemsInternal<T>(List<T> list, int nbOfItemsToReturn, Func<T, bool> filterPredicate = null)
			where T : class
		{
			if (list is null) throw new ArgumentNullException(nameof(list));
			if (nbOfItemsToReturn <= 0) throw new ArgumentException(nameof(nbOfItemsToReturn));

			List<T> returnList = new List<T>();
			for (int i = 0; i < nbOfItemsToReturn; i++)
			{
				T item = GetRandomisedItemInternal(list, filterPredicate);

				returnList.Add(item);
			}
			return returnList.ToArray();
		}
	}
}
