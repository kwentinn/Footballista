using Footballista.BuildingBlocks.Domain;
using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Players.Features;
using System.Collections.Generic;
using System.Linq;

namespace Footballista.Players.Builders.Generators.FeatureGeneration.RatingRanges
{
    public record AgeRange : NamedRatingRange
    {
        public static AgeRange VeryYoung => new AgeRange(nameof(VeryYoung), new Range<PersonAge>(1, 16), new Range<Rating>(.49, .51));
        public static AgeRange Young => new AgeRange(nameof(Young), new Range<PersonAge>(16, 24), new Range<Rating>(.6, .7));
        public static AgeRange Average => new AgeRange(nameof(Average), new Range<PersonAge>(24, 30), new Range<Rating>(.98, .99));
        public static AgeRange CloseToRetirement => new AgeRange(nameof(CloseToRetirement), new Range<PersonAge>(30, 50), new Range<Rating>(.79, .81));

        private static readonly List<AgeRange> ageRanges = new List<AgeRange>
        {
            VeryYoung, Young, Average, CloseToRetirement
        };
        private readonly Range<PersonAge> ageRange;

        private AgeRange(string name, Range<PersonAge> ageRange, Range<Rating> ratingRange) : base(name, ratingRange)
        {
            this.ageRange = ageRange;
        }

        public static Range<Rating> GetRatingForAge(PersonAge age)
        {
            AgeRange ar = ageRanges.FirstOrDefault(ar => ar.ageRange.IsValueInRange(age));
            return ar.ratingRange;
        }
    }
}
