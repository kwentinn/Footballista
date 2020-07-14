using Footballista.Wasm.Shared.Data.Competitions;

namespace Footballista.Wasm.Shared.Data.Careers
{
	public class Career
	{
		public string Name { get; }
		public SimpleDate CurrentDate { get; }
		public Manager Manager { get; }

		public Competition CurrentCompetition { get; }
		public Season CurrentSeason { get; }
		public int CurrentRank { get; } = 0;
		public string UpcomingEvents { get; }

		public static Career DefaultCareer => new Career("Default career", Competition.Ligue1);

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
