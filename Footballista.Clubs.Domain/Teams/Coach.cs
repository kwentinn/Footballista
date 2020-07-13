namespace Footballista.Clubs.Domain.Teams
{
	public class Coach
	{
		public string Firstname { get; }
		public string Lastname { get; }

		public Coach(string firstname, string lastname)
		{
			Firstname = firstname;
			Lastname = lastname;
		}
	}
}
