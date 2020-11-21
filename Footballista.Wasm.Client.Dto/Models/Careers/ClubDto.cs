using System;

namespace Footballista.Wasm.Client.Dto.Models.Careers
{
	public class ClubDto
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Abbreviation { get; set; }
		public string City { get; set; }
		public string Country { get; set; }
	}
}
