namespace Footballista.Wasm.Shared.Data
{
	public class City
	{
		public City(string name, string country)
		{
			Name = name;
			Country = country;
		}

		public string Name { get; set; }
		public string Country { get; set; }
	}
}
