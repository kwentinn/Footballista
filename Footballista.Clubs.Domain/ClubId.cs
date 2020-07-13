using Footballista.BuildingBlocks.Domain;
using System;

namespace Footballista.Clubs.Domain
{
	public class ClubId : TypedIdValueBase
	{
		public ClubId(Guid value) : base(value) { }
	}
}