using Footballista.Wasm.Shared.Data.Competitions;

namespace Footballista.Wasm.Shared.Data.Careers
{
	public class Career
	{
		public string Name { get; set; }
		public DateDto CurrentDate { get; set; }
		public Manager Manager { get; set; }

		public Competition CurrentCompetition { get; set; }
		public Season CurrentSeason { get; set; }
		public int CurrentRank { get; set; } = 0;
		public string UpcomingEvents { get; set; }

		public static Career DefaultCareer => new Career("Default career", Competition.Ligue1);

		/// <summary>
		/// Empty constructor for deserialisation in wasm client
		/// </summary>
		public Career()
		{
		}
		public Career(string name, Competition currentCompetition)
		{
			Name = name;
			CurrentDate = Season.Default.Start;
			Manager = Manager.DefaultManager;
			CurrentCompetition = currentCompetition;
			CurrentSeason = Season.Default;
		}
	}
}
