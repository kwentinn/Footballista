using System;

namespace Footballista.Wasm.Shared.Data.Clubs
{
	public class Club
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Abbreviation { get; set; }
		public City City { get; set; }

		public static Club DefaultClub 
			=> new Club
			(
				Guid.Parse("2a3fb625-858c-438c-a40f-f8049401c350"),
				"Montpellier Hérault Sport Club",
				"MHSC",
				new City("Montpellier", "France")
			);

		public Club(Guid id, string name, string abbreviation, City city)
		{
			Id = id;
			Name = name;
			Abbreviation = abbreviation;
			City = city;
		}

		public string ToShortString() => this.Abbreviation;
		public string ToLongString() => this.Name;
	}
}
