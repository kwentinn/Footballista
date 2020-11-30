using Footballista.BuildingBlocks.Domain;

namespace Footballista.Game.Domain.Players.PlayerNames.Rules
{
	public class LastNameNotEmptyRule : IBusinessRule
	{
		private readonly string _lastname;

		public string Message => "Lastname is required";

		public LastNameNotEmptyRule(string firstname)
		{
			_lastname = firstname;
		}

		public bool IsBroken() => string.IsNullOrEmpty(_lastname);
	}
}
