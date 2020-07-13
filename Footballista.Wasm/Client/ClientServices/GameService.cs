using Blazored.LocalStorage;
using Footballista.Wasm.Client.LocalStorage;
using Footballista.Wasm.Shared.Data.Careers;
using Footballista.Wasm.Shared.Data.Competitions;
using System;

namespace Footballista.Wasm.Client.ClientServices
{
	public class GameService
	{
		private readonly ISyncLocalStorageService _localStorageService;
		public Career CurrentGame { get; private set; }

		public GameService(ISyncLocalStorageService localStorageService)
		{
			_localStorageService = localStorageService;
		}

		public void Load()
		{
			CurrentGame = _localStorageService.GetItem<Career>(LocalStorageKeys.CurrentCareer);
			//SetCurrentCareerInLocalStorage(Career.DefaultCareer);
		}
		public void StartNewCareer(string careerName, Competition competition)
		{
			if (string.IsNullOrEmpty(careerName)) throw new ArgumentException(nameof(careerName));
			if (competition is null) throw new ArgumentNullException(nameof(competition));

			SetCurrentCareerInLocalStorage(new Career(careerName, competition));
		}

		private void SetCurrentCareerInLocalStorage(Career career)
		{
			CurrentGame = career;
			_localStorageService.SetItem(LocalStorageKeys.CurrentCareer, career);
		}
	}
}
