using Footballista.Wasm.Shared.Data.Competitions;
using System;
using System.Collections.Generic;

namespace Footballista.Wasm.Client.NewCareer
{
	public partial class StartNewCareer
	{
		private List<Competition> AvailableCompetitions = new List<Competition>
		{
			Competition.Ligue1,
			Competition.Ligue2
		};
		internal string CareerName { get; set; }
		internal int SelectedCompetitionId { get; set; } = Competition.Ligue1.Id;

		public Competition SelectedCompetition
		{
			get
			{
				if (SelectedCompetitionId <= 0)
					return null;
				return AvailableCompetitions
					.Find(c => c.Id == SelectedCompetitionId);
			}
		}

		void StartNewCareerClick()
		{
			Console.WriteLine("start career clicked !");
			Console.WriteLine(SelectedCompetition);
			Console.WriteLine(CareerName);

			GameService.StartNewCareer(CareerName, SelectedCompetition);

			NavigateToHome();
		}
		void CancelClick()
		{
			Console.WriteLine("cancel clicked !");

			NavigateToHome();
		}

		private void NavigateToHome()
		{
			Nav.NavigateTo("/home", forceLoad: true);
		}
	}
}
