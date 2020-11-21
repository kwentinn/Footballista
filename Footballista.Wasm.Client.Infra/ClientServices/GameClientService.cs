using AutoMapper;
using Blazored.LocalStorage;
using Footballista.BuildingBlocks.Domain;
using Footballista.Wasm.Client.Domain.ClientServices;
using Footballista.Wasm.Client.Dto.Models.Careers;
using Footballista.Wasm.Client.Infra.LocalStorage;
using Footballista.Wasm.Shared.Data.Careers;
using Footballista.Wasm.Shared.Data.Clubs;
using Footballista.Wasm.Shared.Data.Competitions;

namespace Footballista.Wasm.Client.Infra.ClientServices
{
	public class GameClientService : IGameService
	{
		private readonly ISyncLocalStorageService _localStorageService;
		private readonly IMapper _mapper;

		public Career CurrentGame { get; private set; }

		public GameClientService(
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

		public void StartNewCareer(string careerName, Club club, Competition competition, Manager manager)
		{
			EnsureInputParametersAreOK(careerName, competition);

			Career career = Career.StartNew(careerName, club, competition, manager: manager);

			SetCurrentCareerInLocalStorage(career);
			CurrentGame = career;
		}

		private static void EnsureInputParametersAreOK(string careerName, Competition competition)
		{
			Ensure.IsNotNullOrEmpty(careerName, nameof(careerName));
			Ensure.IsNotNull(competition, nameof(competition));
		}

		private void SetCurrentCareerInLocalStorage(Career career)
		{
			CareerDto careerDto = _mapper.Map<CareerDto>(career);
			_localStorageService.SetItem(LocalStorageKeys.CurrentCareer, careerDto);
		}


		public Career GetCurrentCareer()
		{
			CareerDto currentGame = _localStorageService
				.GetItem<CareerDto>(LocalStorageKeys.CurrentCareer);
			return _mapper.Map<Career>(currentGame);
		}

		public void ExitCareer()
			=> _localStorageService.RemoveItem(LocalStorageKeys.CurrentCareer);
	}
}
