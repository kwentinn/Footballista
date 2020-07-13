namespace Footballista.Clubs.Domain.Teams
{
	public class Team
	{
		public Coach Coach { get; }
		public AgeCategory AgeCategory { get; }

		public Team(Coach coach, AgeCategory ageCategory)
		{
			Coach = coach;
			AgeCategory = ageCategory;
		}
	}
}
