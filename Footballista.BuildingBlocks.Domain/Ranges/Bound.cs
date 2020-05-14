using System;
using System.Diagnostics;

namespace Footballista.BuildingBlocks.Domain
{
	[DebuggerDisplay("[{BoundType} {BoundValue}]")]
	public class Bound<T> where T : IComparable<T>
	{
		public T BoundValue { get; }
		public BoundType BoundType { get; }

		public Bound(T boundValue, BoundType boundType)
		{
			if (boundValue == null) throw new ArgumentNullException(nameof(boundValue));

			BoundValue = boundValue;
			BoundType = boundType;
		}

		public static Bound<T> CreateOpenBound(T boundValue) => new Bound<T>(boundValue, BoundType.Open);
		public static Bound<T> CreateClosedBound(T boundValue) => new Bound<T>(boundValue, BoundType.Closed);
	}
}
