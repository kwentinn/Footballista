namespace Footballista.Wasm.Shared.Data.Clubs
{
    public class Club
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Abbreviation { get; set; }

		public static Club DefaultClub => new Club(1, "Montpellier Hérault Sport Club", "MHSC");

		public Club(int id, string name, string abbreviation)
		{
			Id = id;
			Name = name;
			Abbreviation = abbreviation;
		}

		public string ToShortString() => this.Abbreviation;
		public string ToLongString() => this.Name;
	}
}
