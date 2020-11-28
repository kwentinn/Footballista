using Footballista.BuildingBlocks.Domain.Percentiles;
using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Players.Domain.Features;
using Footballista.Players.Domain.Persons;
using Footballista.Players.Domain.Physique;
using Footballista.Players.Domain.PlayerNames;
using Footballista.Players.Domain.Positions;
using Footballista.Players.Features.GlobalRatingCalculators;
using System.Diagnostics;

namespace Footballista.Players.Domain
{
	[DebuggerDisplay("{Name} {PlayerPosition}")]
	public sealed class Player : Person
	{
		public PhysicalFeatureSet PhysicalFeatureSet { get; }
		public PlayerPosition PlayerPosition { get; }
		public Percentile Percentile { get; }
		public Foot FavouriteFoot { get; }
		public BodyMassIndex Bmi { get; }

		private readonly GlobalRatingCalculator _globalRatingCalculator = new GlobalRatingCalculator();

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
