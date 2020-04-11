using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Players.Persons;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Footballista.Players.Evolutions
{
	public abstract class GrowthCurve<T>
	{
		public ReadOnlyCollection<T> Points => _points.AsReadOnly();
		private readonly List<T> _points = new List<T>();

		public Country Country { get; }
		public Gender Gender { get; }

		protected GrowthCurve(Country country, Gender gender, List<T> points)
		{
			if (points is null) throw new ArgumentNullException(nameof(points));

			_points.AddRange(points);
			Country = country;
			Gender = gender;
		}
	}

	public class KilogramMassGrowthCurve : GrowthCurve<KilogramGrowth>
	{
		//public static KilogramMassGrowthCurve MinimumCurve
		//{
		//	get
		//	{
		//		return new KilogramMassGrowthCurve
		//		(
		//			country: new Country("FR"),
		//			gender: Gender.Male,
		//			points: new List<KilogramGrowth>
		//			{
		//				new KilogramGrowth(new AgeInYear(1), new Kilogram(5)),
		//			});
		//	}
		//}

		public KilogramMassGrowthCurve(Country country, Gender gender, List<KilogramGrowth> points) : base(country, gender, points)
		{
		}
	}

	//public  class MassGrowthCurve<TMassUnit> : GrowthCurve<MassGrowth>
	//	where TMassUnit : MassUnit, new()
	//{
	//	public static MassGrowthCurve<TMassUnit> MinimumMassGrowthCurve
	//	{
	//		get
	//		{
	//			return new MassGrowthCurve<TMassUnit>(new List<MassGrowth>()
	//			{
	//				new MassGrowth(new AgeInYear(0), new TMassUnit())
	//			});
	//		}
	//	}
	//	protected MassGrowthCurve(List<MassGrowth> points) : base(points)
	//	{
	//	}
	//}

	//public class HeightGrowthCurve : GrowthCurve<LengthGrowth>
	//{
	//	public HeightGrowthCurve(List<LengthGrowth> points) : base(points)
	//	{
	//	}
	//}
}
