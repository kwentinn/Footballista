using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Players.Features;
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
		public ReadOnlyCollection<PlayerPosition> PlayerPositions => playerPositions.AsReadOnly();
		private List<PlayerPosition> playerPositions = new List<PlayerPosition>();

		public PhysicalFeatureSet PhysicalFeatureSet { get; }

		public Length Height { get; }
		public Mass Weight { get; }

		public Foot FavouriteFoot { get; }

		internal Player
		(
			PersonId id,
			Firstname firstname,
			Lastname lastname,
			Gender gender,
			Date dob,
			Location birthLocation,
			Foot favouriteFoot,
			Length height,
			Mass weight,
			PhysicalFeatureSet physicalFeatureSet,
			params Country[] nationalities
		) : base(id, firstname, lastname, gender, dob, birthLocation, nationalities)
		{
			FavouriteFoot = favouriteFoot;
			Height = height;
			Weight = weight;
			PhysicalFeatureSet = physicalFeatureSet;
		}

		public static Player CreatePlayer
		(
			Firstname firstname,
			Lastname lastname,
			Gender gender,
			Date dob,
			Location birthLocation,
			Foot favouriteFoot,
			Length height,
			Mass weight,
			PhysicalFeatureSet physicalFeatureSet,
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
			height,
			weight,
			physicalFeatureSet,
			nationalities
		);
	}
}
