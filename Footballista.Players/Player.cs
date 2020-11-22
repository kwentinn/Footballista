using Footballista.BuildingBlocks.Domain.Percentiles;
using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Players.Features;
using Footballista.Players.Features.GlobalRatingCalculators;
using Footballista.Players.Persons;
using Footballista.Players.Physique;
using Footballista.Players.PlayerNames;
using Footballista.Players.Positions;
using System.Diagnostics;

namespace Footballista.Players
{
	[DebuggerDisplay("{Name} {PlayerPosition}")]
	public sealed class Player : Person
	{
		public PhysicalFeatureSet PhysicalFeatureSet { get; }
		public PlayerPosition PlayerPosition { get; }
		public Percentile Percentile { get; }
		public Foot FavouriteFoot { get; }
		public BodyMassIndex Bmi { get; }

		public readonly GlobalRatingCalculator _globalRatingCalculator = new GlobalRatingCalculator();

		public Rating GeneralRating => _globalRatingCalculator.Calculate(PlayerPosition, PhysicalFeatureSet);

		private Player
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
	}
}
