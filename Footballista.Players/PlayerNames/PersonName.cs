using Footballista.BuildingBlocks.Domain;
using Footballista.Players.PlayerNames.Rules;
using System.Diagnostics;

namespace Footballista.Players.PlayerNames
{
	[DebuggerDisplay("{Firstname} {Lastname}")]
	public class PersonName : ValueObject
	{
		public Firstname Firstname { get; }
		public Lastname Lastname { get; }

		public PersonName(Firstname firstname, Lastname lastname)
		{
			CheckRule(new NameCannotBeEmptyRule(firstname, lastname));

			Firstname = firstname;
			Lastname = lastname;
		}
	}
}
