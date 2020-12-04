using Footballista.BuildingBlocks.Domain.Percentiles;
using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Game.Domain.Players.Features;
using Footballista.Game.Domain.Players.Persons;
using Footballista.Game.Domain.Players.Physique;
using Footballista.Game.Domain.Players.PlayerNames;
using Footballista.Game.Domain.Players.Positions;
using Footballista.Players.Features.GlobalRatingCalculators;
using System;
using System.Diagnostics;

namespace Footballista.Game.Domain.Players
{
    [DebuggerDisplay("{Name} {PlayerPosition}")]
    public class Player : Person
    {
        public PhysicalFeatureSet PhysicalFeatureSet { get; }
        public PlayerPosition PlayerPosition { get; }
        public Percentile Percentile { get; }
        public Foot FavouriteFoot { get; }
        public BodyMassIndex Bmi { get; }

        private readonly GlobalRatingCalculator _globalRatingCalculator = new GlobalRatingCalculator();

        public Rating GeneralRating => _globalRatingCalculator.Calculate(PlayerPosition, PhysicalFeatureSet);

        protected Player
        (
            PersonId id,
            PersonName name,
            Gender gender,
            BirthInfo birthInfo,
            Foot favouriteFoot,
            BodyMassIndex bmi,
            Percentile percentile,
            PhysicalFeatureSet physicalFeatureSet,
            PlayerPosition playerPosition,
            params Country[] nationalities
        ) : base(id, name, gender, birthInfo, nationalities)
        {
            FavouriteFoot = favouriteFoot;
            Bmi = bmi;
            Percentile = percentile;
            PhysicalFeatureSet = physicalFeatureSet;
            PlayerPosition = playerPosition;
        }

        public static Player CreatePlayer
        (
            PersonName name,
            Gender gender,
            BirthInfo birthInfo,
            Foot favouriteFoot,
            BodyMassIndex bmi,
            Percentile percentile,
            PhysicalFeatureSet physicalFeatureSet,
            PlayerPosition playerPosition,
            params Country[] nationalities
        ) => new Player
        (
            PersonId.CreateNew(),
            name,
            gender,
            birthInfo,
            favouriteFoot,
            bmi,
            percentile,
            physicalFeatureSet,
            playerPosition,
            nationalities
        );

        internal static Player Rehydrate(
            PersonId id,
            PersonName name, Gender gender,
            BirthInfo birthInfo,
            Foot favouriteFoot,
            BodyMassIndex bmi,
            Percentile percentile,
            PhysicalFeatureSet physicalFeatureSet,
            PlayerPosition playerPosition,
            Country[] nationalities)
        {
            return new Player
            (
                id,
                name,
                gender,
                birthInfo,
                favouriteFoot,
                bmi,
                percentile,
                physicalFeatureSet,
                playerPosition,
                nationalities
            );
        }
    }
}
