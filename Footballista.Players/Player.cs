using Footballista.BuildingBlocks.Domain.Percentiles;
using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Players.Features;
using Footballista.Players.Growths;
using Footballista.Players.Persons;
using Footballista.Players.PlayerNames;
using Footballista.Players.Positions;
using Itenso.TimePeriod;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnitsNet;

namespace Footballista.Players
{
	public class Player : Person
	{
		//public ReadOnlyCollection<PlayerPosition> PlayerPositions => _playerPositions.AsReadOnly();
		//private List<PlayerPosition> _playerPositions = new List<PlayerPosition>();
		public PhysicalFeatureSet PhysicalFeatureSet { get; }
		public PlayerPosition PlayerPosition { get; }
		public Percentile Percentile { get; }
		public Foot FavouriteFoot { get; }
		public BodyMassIndex Bmi { get; }

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
