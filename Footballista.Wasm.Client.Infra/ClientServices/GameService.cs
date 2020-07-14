using AutoMapper;
using Blazored.LocalStorage;
using Footballista.Wasm.Client.Domain.ClientServices;
using Footballista.Wasm.Client.Dto.Models.Careers;
using Footballista.Wasm.Client.Infra.LocalStorage;
using Footballista.Wasm.Shared.Data.Careers;
using Footballista.Wasm.Shared.Data.Competitions;
using System;

namespace Footballista.Wasm.Client.Infra.ClientServices
{
	public class GameService : IGameService
	{
		private readonly ISyncLocalStorageService _localStorageService;
		private readonly IMapper _mapper;

		public Career CurrentGame { get; private set; }

		public GameService(
			ISyncLocalStorageService localStorageService,
			IMapper mapper
		)
		{
			_localStorageService = localStorageService;
			_mapper = mapper;
		}

		public void Load()
		{
			CurrentGame = GetCurrentCareer();
		}

		public void StartNewCareer(string careerName, Competition competition)
		{
			if (string.IsNullOrEmpty(careerName)) throw new ArgumentException(nameof(careerName));
			if (competition is null) throw new ArgumentNullException(nameof(competition));

			var career = new Career(careerName, competition);
			SetCurrentCareerInLocalStorage(career);
			CurrentGame = career;
		}

		public Career GetCurrentCareer()
		{
			CareerDto currentGame = _localStorageService.GetItem<CareerDto>(LocalStorageKeys.CurrentCareer);
			return _mapper.Map<Career>(currentGame);
		}

		private void SetCurrentCareerInLocalStorage(Career career)
		{
			CareerDto careerDto = _mapper.Map<CareerDto>(career);
			_localStorageService.SetItem(LocalStorageKeys.CurrentCareer, careerDto);
		}

		public void ExitCareer()
			=> _localStorageService.RemoveItem(LocalStorageKeys.CurrentCareer);
	}
}
