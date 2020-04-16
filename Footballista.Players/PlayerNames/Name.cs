namespace Footballista.Players.PlayerNames
{
	public class Name
	{
		public Firstname Firstname { get; }
		public Lastname Lastname { get; }

		public Name(Firstname firstname, Lastname lastname)
		{
			Firstname = firstname;
			Lastname = lastname;
		}
	}
}
