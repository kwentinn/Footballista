using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Players.Features;
using Footballista.Players.Persons;
using Footballista.Players.Positions;
using Itenso.TimePeriod;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Footballista.Players
{
	public class Player : Person
	{
		public ReadOnlyCollection<PlayerPosition> PlayerPositions => playerPositions.AsReadOnly();
		private List<PlayerPosition> playerPositions = new List<PlayerPosition>();

		public PhysicalFeatureSet PhysicalFeatureSet { get; }

		public UnitsNet.Length Height { get; }
		public UnitsNet.Mass Weight { get; }

		internal Player
		(
			PersonId id,
			string firstname,
			string lastname,
			Gender gender,
			Date dob,
			Location birthLocation,
			params Country[] nationalities
		)
			: base(id, firstname, lastname, gender, dob, birthLocation, nationalities)
		{
		}

		internal Player(Person person) :
			base(person.Id, person.Firstname, person.Lastname, person.Gender, person.BirthInfo.DateOfBirth, person.BirthInfo.BirthLocation, person.Nationalities.ToArray())
		{
		}

		/// <summary>
		/// Handle player growth.
		/// </summary>
		public void Grow()
		{

		}
	}
}
