using Blazored.LocalStorage;
using Footballista.Wasm.Client.LocalStorage;
using Footballista.Wasm.Shared.Data.Careers;

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
			CurrentGame = Career.DefaultCareer;
			System.Console.WriteLine(CurrentGame);
			_localStorageService.SetItem(LocalStorageKeys.CurrentCareer, CurrentGame);
		}
	}
}
