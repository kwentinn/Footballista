using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Players.Persons;
using Footballista.Players.Positions;
using Itenso.TimePeriod;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Footballista.Players
{
	public class Player : Person
	{
		public ReadOnlyCollection<PlayerPosition> PlayerPositions => playerPositions.AsReadOnly();
		private List<PlayerPosition> playerPositions = new List<PlayerPosition>();

		internal Player(PersonId id, string firstname, string lastname, Gender gender, Date dob, Location birthLocation, params Country[] nationalities) :
			base(id, firstname, lastname, gender, dob, birthLocation, nationalities)
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
