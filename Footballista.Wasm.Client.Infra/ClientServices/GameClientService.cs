using AutoMapper;
using Blazored.LocalStorage;
using Footballista.BuildingBlocks.Domain;
using Footballista.Wasm.Client.Domain.ClientServices;
using Footballista.Wasm.Client.Dto.Models.Careers;
using Footballista.Wasm.Client.Infra.LocalStorage;
using Footballista.Wasm.Shared.Data.Careers;
using Footballista.Wasm.Shared.Data.Clubs;
using Footballista.Wasm.Shared.Data.Competitions;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Footballista.Wasm.Client.Infra.ClientServices
{
	public class GameClientService : IGameService
	{
		private readonly ISyncLocalStorageService _localStorageService;
		private readonly IToasterService _toasterService;
		private readonly IMapper _mapper;
		private readonly HttpClient _httpClient;

		public Career CurrentGame { get; private set; }

		public GameClientService(
			HttpClient httpClient,
			ISyncLocalStorageService localStorageService,
			IToasterService toasterService,
			IMapper mapper
		)
		{
			_httpClient = httpClient;
			_localStorageService = localStorageService;
			_toasterService = toasterService;
			_mapper = mapper;
		}

		public void Load()
		{
			CurrentGame = GetCurrentCareer();
		}

		public async Task StartNewCareerAsync(string careerName, Club club, Competition competition, Manager manager)
		{
			Ensure.IsNotNullOrEmpty(careerName);
			Ensure.IsNotNull(competition);

			Career career = Career.StartNew(careerName, club, competition, manager: manager);

			SetCurrentCareerInLocalStorage(career);
			CurrentGame = career;

			HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("career/create", _mapper.Map<CareerDto>(career));
			if (httpResponseMessage.IsSuccessStatusCode)
			{
				_toasterService.ShowSuccess("Carrière créée avec succès.");
			}
		}

		private void SetCurrentCareerInLocalStorage(Career career)
		{
			CareerDto careerDto = _mapper.Map<CareerDto>(career);
			_localStorageService.SetItem(LocalStorageKeys.CURRENT_CAREER, careerDto);
		}


		public Career GetCurrentCareer()
		{
			CareerDto currentGame = _localStorageService
				.GetItem<CareerDto>(LocalStorageKeys.CURRENT_CAREER);
			return _mapper.Map<Career>(currentGame);
		}

		public void ExitCareer()
			=> _localStorageService.RemoveItem(LocalStorageKeys.CURRENT_CAREER);
	}
}
