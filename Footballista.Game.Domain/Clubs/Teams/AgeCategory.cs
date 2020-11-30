using Footballista.BuildingBlocks.Domain;
using Footballista.BuildingBlocks.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace Footballista.Game.Domain.Clubs.Teams
{
    public class AgeCategory
    {
        public string Name { get; }
        public BoundedRange<PersonAge> AgeRange { get; }

        public static AgeCategory U15 => new AgeCategory
        (
            nameof(U15),
            new BoundedRange<PersonAge>
            (
                new IncludingBound<PersonAge>(PersonAge.FromYears(12)),
                new ExcludingBound<PersonAge>(PersonAge.FromYears(15))
            )
        );
        public static AgeCategory U17 => new AgeCategory
        (
            nameof(U17),
            new BoundedRange<PersonAge>
            (
                new IncludingBound<PersonAge>(PersonAge.FromYears(15)),
                new ExcludingBound<PersonAge>(PersonAge.FromYears(17))
            )
        );
        public static AgeCategory U19 => new AgeCategory
        (
            nameof(U19),
            new BoundedRange<PersonAge>
            (
                new IncludingBound<PersonAge>(PersonAge.FromYears(17)),
                new ExcludingBound<PersonAge>(PersonAge.FromYears(19))
            )
        );

        private static List<AgeCategory> _allAgeCategories = new List<AgeCategory>
        {
            U15, U17, U19
        };

        private AgeCategory(string name, BoundedRange<PersonAge> ageRange)
        {
            Name = name;
            AgeRange = ageRange;
        }
    }
}
