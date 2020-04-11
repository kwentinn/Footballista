﻿using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Players.Persons;
using Footballista.Players.Positions;
using Itenso.TimePeriod;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;

namespace Footballista.Players
{
	public abstract class Player : Person
	{
		public ReadOnlyCollection<PlayerPosition> PlayerPositions => playerPositions.AsReadOnly();
		private List<PlayerPosition> playerPositions = new List<PlayerPosition>();

		internal Player(string firstname, string lastname, Gender gender, Date dob, Location birthLocation, params Country[] nationalities)
			: base(firstname, lastname, gender, dob, birthLocation, nationalities)
		{
		}

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
