using Footballista.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Footballista.Players.Domain.PlayerNames.Rules
{
	public class FirstNameNotEmptyRule : IBusinessRule
	{
		private readonly string _firstname;

		public string Message => "Firstname is required";

		public FirstNameNotEmptyRule(string firstname)
		{
			_firstname = firstname;
		}

		public bool IsBroken() => string.IsNullOrEmpty(_firstname);
	}
}
