using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Players.Evolutions;
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
		public class PlayerBuilder
		{
			public Player Build(Person personInfo, StatureGrowthCurve statureGrowthCurve, WeightGrowthCurve weightGrowthCurve)
			{
				return new Player(personInfo, statureGrowthCurve, weightGrowthCurve);
			}
		}

		public ReadOnlyCollection<PlayerPosition> PlayerPositions => playerPositions.AsReadOnly();
		private List<PlayerPosition> playerPositions = new List<PlayerPosition>();

		public StatureGrowthCurve StatureGrowthCurve { get; }
		public WeightGrowthCurve WeightGrowthCurve { get; }

		internal Player(Person personInfo, StatureGrowthCurve statureGrowthCurve, WeightGrowthCurve weightGrowthCurve)
		: base
		(
			personInfo.Firstname,
			personInfo.Lastname,
			personInfo.Gender,
			personInfo.DateOfBirth,
			personInfo.BirthLocation,
			personInfo.Nationalities.ToArray()
		)
		{
			StatureGrowthCurve = statureGrowthCurve;
			WeightGrowthCurve = weightGrowthCurve;
		}
		internal Player(string firstname, string lastname, Gender gender, Date dob, Location birthLocation, Country[] nationalities, StatureGrowthCurve statureGrowthCurve, WeightGrowthCurve weightGrowthCurve)
			: base(firstname, lastname, gender, dob, birthLocation, nationalities)
		{
			StatureGrowthCurve = statureGrowthCurve;
			WeightGrowthCurve = weightGrowthCurve;
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
