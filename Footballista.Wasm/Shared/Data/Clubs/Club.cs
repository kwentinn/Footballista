using System;

namespace Footballista.Wasm.Shared.Data.Clubs
{
	public class Club
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Abbreviation { get; set; }
		public City City { get; set; }
	}
}
