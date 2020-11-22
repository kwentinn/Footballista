using System;

namespace Footballista.Wasm.Client.NewCareer.Data
{
	public class ManagerData
	{
		internal string Firstname { get; set; }
		internal string Lastname { get; set; }
		internal DateTime? DateOfBirth { get; set; }
		internal string Country { get; set; }

		public static ManagerData Default => new ManagerData
		{
			Firstname = "Jean-Pierre",
			Lastname = "Edouard",
			Country = "France",
			DateOfBirth = new DateTime(1971, 4, 23)
		};

		public ManagerData() { }
	}
}
