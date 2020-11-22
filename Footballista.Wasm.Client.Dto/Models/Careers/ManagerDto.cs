namespace Footballista.Wasm.Client.Dto.Models.Careers
{
	public class ManagerDto
	{
		public GenderDto Gender { get; set; }
		public string Firstname { get; set; }
		public string Lastname { get; set; }
		public SimpleDateDto DateOfBirth { get; set; }
		public string Country { get; set; }
	}
}
