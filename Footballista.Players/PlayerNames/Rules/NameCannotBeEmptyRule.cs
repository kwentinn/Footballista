﻿using Footballista.BuildingBlocks.Domain;
using Footballista.Players.Domain.PlayerNames;

namespace Footballista.Players.Domain.PlayerNames.Rules
{
	public class NameCannotBeEmptyRule : IBusinessRule
	{
		private readonly Firstname _firstname;
		private readonly Lastname _lastname;

		public string Message => "Lastname is required";

		public NameCannotBeEmptyRule(Firstname firstname, Lastname lastname)
		{
			_firstname = firstname;
			_lastname = lastname;
		}

		public bool IsBroken() => _firstname is null || _lastname is null;
	}
}
