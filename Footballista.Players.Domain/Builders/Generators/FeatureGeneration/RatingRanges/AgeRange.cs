using Footballista.BuildingBlocks.Domain;
using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Players.Domain.Features;
using System.Collections.Generic;
using System.Linq;

namespace Footballista.Players.Domain.Builders.Generators.FeatureGeneration.RatingRanges
{
	public record AgeRange : NamedRatingRange
	{
		public static AgeRange VeryYoung => new AgeRange(nameof(VeryYoung), new Range<PersonAge>(1, 16), new Range<Rating>(.49, .51));
		public static AgeRange Young => new AgeRange(nameof(Young), new Range<PersonAge>(16, 24), new Range<Rating>(.6, .7));
		public static AgeRange Average => new AgeRange(nameof(Average), new Range<PersonAge>(24, 30), new Range<Rating>(.98, .99));
		public static AgeRange CloseToRetirement => new AgeRange(nameof(CloseToRetirement), new Range<PersonAge>(30, 50), new Range<Rating>(.79, .81));

		private static readonly List<AgeRange> _ageRanges = new List<AgeRange>
		{
			VeryYoung, Young, Average, CloseToRetirement
		};
		private readonly Range<PersonAge> _ageRange;

		private AgeRange(string name, Range<PersonAge> ageRange, Range<Rating> ratingRange) : base(name, ratingRange)
		{
			this._ageRange = ageRange;
		}

		public static Range<Rating> GetRatingRangeForAge(PersonAge age)
		{
			AgeRange ar = _ageRanges.FirstOrDefault(ar => ar._ageRange.IsValueInRange(age));
			return ar.RatingRange;
		}
	}
}
