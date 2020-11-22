using Blazored.LocalStorage;
using Footballista.Wasm.Client.Domain.ClientServices;
using Footballista.Wasm.Client.Infra.LocalStorage;
using System.Globalization;
using System.Threading.Tasks;

namespace Footballista.Wasm.Client.Infra.ClientServices
{
	public class CurrentCultureService : ICurrentCultureService
	{
		private readonly CultureInfo _defaultCulture = new CultureInfo("en-us");

		private readonly ILocalStorageService _localStorageService;
		private readonly ISyncLocalStorageService _syncLocalStorageService;

		public CurrentCultureService(ILocalStorageService localStorageService, ISyncLocalStorageService syncLocalStorageService)
		{
			_localStorageService = localStorageService;
			_syncLocalStorageService = syncLocalStorageService;
		}

		public async Task<string> GetCurrentCultureFromLocalStorage()
			=> await _localStorageService.GetItemAsync<string>(LocalStorageKeys.CURRENT_CULTURE);
		public async Task SetDefaultCurrentCultureAsync()
		{
			CultureInfo culture = _defaultCulture;
			string result = await GetCurrentCultureFromLocalStorage();
			if (!string.IsNullOrEmpty(result))
			{
				culture = new CultureInfo(result);
			}
			SetCurrentCultureForApplication(culture);
		}
		public async Task SetCurrentCultureAsync(string cultureCode)
		{
			var culture = new CultureInfo(cultureCode);
			SetCurrentCultureForApplication(culture);
			await _localStorageService.SetItemAsync(LocalStorageKeys.CURRENT_CULTURE, cultureCode);
		}

		private static void SetCurrentCultureForApplication(CultureInfo culture)
		{
			System.Console.WriteLine($"Setting culture {culture.Name}...");
			
			CultureInfo.DefaultThreadCurrentCulture = culture;
			CultureInfo.DefaultThreadCurrentUICulture = culture;

			System.Console.WriteLine($"Done!");
		}

		public void SetCurrentCulture(string cultureCode)
		{
			var culture = new CultureInfo(cultureCode);
			SetCurrentCultureForApplication(culture);
			_syncLocalStorageService.SetItem(LocalStorageKeys.CURRENT_CULTURE, cultureCode);
		}
	}
}
