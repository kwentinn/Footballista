using Footballista.BuildingBlocks.Domain.Percentiles;
using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Players.Features;
using Footballista.Players.Features.GlobalRatingCalculators;
using Footballista.Players.Persons;
using Footballista.Players.Physique;
using Footballista.Players.PlayerNames;
using Footballista.Players.Positions;
using Itenso.TimePeriod;
using System.Diagnostics;

namespace Footballista.Players
{
	[DebuggerDisplay("{Firstname} {Lastname} {PlayerPosition}")]
	public class Player : Person
	{
		public PhysicalFeatureSet PhysicalFeatureSet { get; }
		public PlayerPosition PlayerPosition { get; }
		public Percentile Percentile { get; }
		public Foot FavouriteFoot { get; }
		public BodyMassIndex Bmi { get; }

		public readonly GlobalRatingCalculator _globalRatingCalculator = new GlobalRatingCalculator();

		public Rating GeneralRating => _globalRatingCalculator.Calculate(PlayerPosition, PhysicalFeatureSet);

		internal Player
		(
			PersonId id,
			Firstname firstname,
			Lastname lastname,
			Gender gender,
			Date dob,
			Location birthLocation,
			Foot favouriteFoot,
			BodyMassIndex bmi,
			Percentile percentile,
			PhysicalFeatureSet physicalFeatureSet,
			PlayerPosition playerPosition,
			params Country[] nationalities
		) : base(id, firstname, lastname, gender, dob, birthLocation, nationalities)
		{
			FavouriteFoot = favouriteFoot;
			Bmi = bmi;
			Percentile = percentile;
			PhysicalFeatureSet = physicalFeatureSet;
			PlayerPosition = playerPosition;
		}

		public static Player CreatePlayer
		(
			Firstname firstname,
			Lastname lastname,
			Gender gender,
			Date dob,
			Location birthLocation,
			Foot favouriteFoot,
			BodyMassIndex bmi,
			Percentile percentile,
			PhysicalFeatureSet physicalFeatureSet,
			PlayerPosition playerPosition,
			params Country[] nationalities
		) => new Player
		(
			PersonId.CreateNew(),
			firstname,
			lastname,
			gender,
			dob,
			birthLocation,
			favouriteFoot,
			bmi,
			percentile,
			physicalFeatureSet,
			playerPosition,
			nationalities
		);
	}
}
