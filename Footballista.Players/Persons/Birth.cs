using Footballista.BuildingBlocks.Domain;
using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Players.Persons.BusinessRules;
using Itenso.TimePeriod;
using System;
using System.Collections.Generic;
using System.Text;

namespace Footballista.Players.Persons
{
	public class Birth : ValueObject
	{
		public Date DateOfBirth { get; }
		public Location BirthLocation { get; }

		public Birth(Date dateOfBirth, Location birthLocation)
		{
			CheckRule(new BirthMustHaveADateRule(dateOfBirth));

			DateOfBirth = dateOfBirth;
			BirthLocation = birthLocation;
		}
	}
}
