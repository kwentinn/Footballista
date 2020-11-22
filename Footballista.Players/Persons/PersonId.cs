using Footballista.BuildingBlocks.Domain;
using System;
using System.Diagnostics;

namespace Footballista.Players.Persons
{
	[DebuggerDisplay("PersonId - [{Value}]")]
	public class PersonId : TypedIdValueBase
	{
		public PersonId(Guid value) : base(value)
		{
		}

		/// <summary>
		/// Creates a new PersonId
		/// </summary>
		/// <returns></returns>
		public static PersonId CreateNew() => new PersonId(Guid.NewGuid());
	}
}
