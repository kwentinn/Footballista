using Footballista.Wasm.Shared.Data.Clubs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Footballista.Wasm.Shared.Data.Competitions
{
	public class CompetitionRanking
	{
		public int Position { get; set; }
		public string ClubName { get; set; }
		public int GamesPlayed { get; set; }
		public int Won { get; set; }
		public int Drawn { get; set; }
		public int Lost { get; set; }
		public int GoalsFor { get; set; }
		public int GoalsAgainst { get; set; }
		public int GoalsDifference { get; set; }
		public int Points { get; set; }
	}
}
