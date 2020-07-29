using Blazorise;
using Footballista.Wasm.Client.Domain.ClientServices;
using Footballista.Wasm.Shared.Data;
using Footballista.Wasm.Shared.Data.Careers;
using Footballista.Wasm.Shared.Data.Competitions;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;

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
		internal string ManagerFirstname { get; set; }
		internal string ManagerLastname { get; set; }
		internal DateTime? ManagerDateOfBirth { get; set; }
		internal string ManagerCountry { get; set; }

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

		public void StartNewCareerClick()
		{
			var dob = new SimpleDate
			(
				ManagerDateOfBirth.Value.Year,
				ManagerDateOfBirth.Value.Month,
				ManagerDateOfBirth.Value.Day
			);
			var manager = Manager.CreateManager
			(
				Gender.Male,
				ManagerFirstname,
				ManagerLastname,
				dob,
				ManagerCountry
			);
			GameService.StartNewCareer(CareerName, SelectedCompetition, manager);

			NavigateToHome();
		}
		public void CancelClick()
		{
			Console.WriteLine("cancel clicked !");

			NavigateToHome();
		}

		protected void NavigateToHome()
		{
			Nav.NavigateTo("/home", forceLoad: true);
		}
	}
}
