namespace Footballista.Wasm.Shared.Data.Competitions
{
	public class Competition
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int Division { get; set; }
		public string Country { get; set; }

		public Competition()
		{
		}
		private Competition(int id, string name, int division, string country)
		{
			Id = id;
			Name = name;
			Division = division;
			Country = country;
		}

		public static Competition Ligue1 => new Competition(1, "Ligue 1", 1, "France");
		public static Competition Ligue2 => new Competition(2, "Ligue 2", 2, "France");

		public static Competition Instantiate(int id, string name, int division, string country)
			=> new Competition(id, name, division, country);

		public override string ToString() => Name;
		
	}
}
