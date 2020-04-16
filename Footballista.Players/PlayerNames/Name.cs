namespace Footballista.Players.PlayerNames
{
	public class Name
	{
		public string Firstname { get; }
		public string Lastname { get; }

		public Name(string firstname, string lastname)
		{
			Firstname = firstname;
			Lastname = lastname;
		}
	}
}
