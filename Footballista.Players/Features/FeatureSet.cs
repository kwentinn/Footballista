using System.Collections.Generic;

namespace Footballista.Players.Features
{
	public abstract class FeatureSet<T>
	{
		protected List<T> _items = new List<T>();
		public T this[int i] => _items[i];
	}
}
