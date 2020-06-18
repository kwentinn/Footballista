namespace Footballista.Wasm.Shared.Data.Careers
{
	public class Career
	{
		public string Name { get; set; }
		public DateDto CurrentDate { get; set; }
		public Manager Manager { get; set; }

		public string CurrentCompetition { get; set; }
		public string CurrentSeason { get; set; }
		public int CurrentRank { get; set; }
		public string UpcomingEvents { get; set; } 

		public static Career DefaultCareer
			=> new Career("Default career", new DateDto(2020, 7, 1), Manager.DefaultManager)
			{
				CurrentCompetition = "League One",
				CurrentSeason = "2020-2021",
				CurrentRank = 5,
				UpcomingEvents = "..."
			};
		
		public Career()
		{
		}
		public Career(string name, DateDto currentDate, Manager manager)
		{
			Name = name;
			CurrentDate = currentDate;
			Manager = manager;
		}
	}
	//public class Competition
	//{
	//	public string Name { get; set; }
	//}
}
