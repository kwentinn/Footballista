using Footballista.Wasm.Shared.Data.Clubs;
using Footballista.Wasm.Shared.Data.Competitions;
using System;

namespace Footballista.Wasm.Shared.Data.Careers
{
	public class Career
	{
		public Guid Id { get; }
		public string Name { get; }
		public SimpleDate CurrentDate { get; }
		public Manager Manager { get; }
		public Club Club { get; }
		public Competition CurrentCompetition { get; }
		public Season CurrentSeason { get; }

		public int CurrentRank { get; } = 0;
		public string UpcomingEvents { get; }

		public static Career DefaultCareer
			=> new Career(Guid.Empty, "Default career", Club.DefaultClub, Competition.Ligue1);

		private Career
		(
			Guid id,
			string name,
			Club club,
			Competition currentCompetition,
			SimpleDate currentDate = null,
			Manager manager = null,
			Season season = null
		)
		{
			Id = id;
			Name = name;
			Club = club;
			Manager = manager ?? Manager.DefaultManager;
			CurrentCompetition = currentCompetition;
			CurrentSeason = season ?? Season.Default;
			CurrentDate = currentDate ?? Season.Default.Start;
		}

		public static Career StartNew
		(
			string name,
			Club club,
			Competition currentCompetition,
			SimpleDate currentDate = null,
			Manager manager = null,
			Season season = null
		)
			=> new Career(Guid.NewGuid(), name, club, currentCompetition, currentDate, manager, season);

		public static Career Instantiate
		(
			Guid id,
			string name,
			Club club,
			Competition currentCompetition,
			SimpleDate currentDate = null,
			Manager manager = null,
			Season season = null
		)
			=> new Career(id, name, club, currentCompetition, currentDate, manager, season);
	}
}
