using System;
using System.Diagnostics;

namespace Footballista.BuildingBlocks.Domain
{
	[DebuggerDisplay("[{BoundType} {BoundValue}]")]
	//public record Bound<T> where T : IComparable<T>
	//{
	//	public T BoundValue { get; }
	//	public BoundType BoundType { get; }

	//	public Bound(T boundValue, BoundType boundType)
	//	{
	//		if (boundValue == null) throw new ArgumentNullException(nameof(boundValue));

	//		BoundValue = boundValue;
	//		BoundType = boundType;
	//	}

	//	public static Bound<T> CreateOpenBound(T boundValue) => new Bound<T>(boundValue, BoundType.Exclude);
	//	public static Bound<T> CreateClosedBound(T boundValue) => new Bound<T>(boundValue, BoundType.Include);
	//}

	public abstract record Bound<T> where T : IComparable<T>
	{
		public T BoundValue { get; }

		public Bound(T boundValue)
		{
			if (boundValue is null) throw new ArgumentNullException(nameof(boundValue));

			BoundValue = boundValue;
		}
	}
    public record ExcludingBound<T> : Bound<T> where T : IComparable<T>
    {
        public ExcludingBound(T boundValue) : base(boundValue)
        {
        }
    }
    public record IncludingBound<T> : Bound<T> where T : IComparable<T>
    {
        public IncludingBound(T boundValue) : base(boundValue)
        {
        }
    }
}
