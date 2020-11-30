using Footballista.BuildingBlocks.Domain;
using Itenso.TimePeriod;
using System;

namespace Footballista.Game.Domain.Players.Persons.Rules
{
	public class BirthMustHaveADateRule : IBusinessRule
	{
		private readonly Date _dateOfBirth;

		public string Message => "Birth must have a date";


		public BirthMustHaveADateRule(Date dateOfBirth)
		{
			_dateOfBirth = dateOfBirth;
		}

		public bool IsBroken()
		{
			return _dateOfBirth.DateTime == DateTime.MinValue;
		}
	}
}
