using Footballista.Wasm.Client.Domain.ClientServices;
using Footballista.Wasm.Client.NewCareer.Data;
using Footballista.Wasm.Client.Routing;
using Footballista.Wasm.Shared.Data;
using Footballista.Wasm.Shared.Data.Careers;
using Footballista.Wasm.Shared.Data.Clubs;
using Footballista.Wasm.Shared.Data.Competitions;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Footballista.Wasm.Client.NewCareer
{
	public class StartNewCareerBase : ComponentBase
	{
		[Inject]
		public IGameService GameService { get; set; }

		[Inject]
		public NavigationManager Nav { get; set; }

		protected List<Competition> AvailableCompetitions = new List<Competition>
		{
			Competition.Ligue1,
			Competition.Ligue2
		};

		internal string CareerName { get; set; }
		internal string Club { get; set; }
		internal ManagerData TheManager { get; set; } = ManagerData.Default;

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

		public async Task StartNewCareerClick()
		{
			SimpleDate dob = new SimpleDate
			(
				TheManager.DateOfBirth.Value.Year,
				TheManager.DateOfBirth.Value.Month,
				TheManager.DateOfBirth.Value.Day
			);
			Manager manager = Manager.CreateManager
			(
				Gender.Male,
				TheManager.Firstname,
				TheManager.Lastname,
				dob,
				TheManager.Country
			);

			Club club = new Club(Guid.Empty, "Montpellier", "MHSC", new City("Montpellier", "France"));

			await GameService.StartNewCareerAsync(CareerName, club, SelectedCompetition, manager);

			NavigateToHome();
		}
		public void CancelClick()
		{
			Console.WriteLine("cancel clicked !");

			NavigateToHome();
		}

		protected void NavigateToHome()
		{
			Nav.NavigateTo(AllRoutes.Home.Url, forceLoad: true);
		}
	}
}
