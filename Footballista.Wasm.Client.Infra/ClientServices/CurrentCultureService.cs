using Blazored.LocalStorage;
using Footballista.Wasm.Client.Domain.ClientServices;
using Footballista.Wasm.Client.Infra.LocalStorage;
using System.Globalization;
using System.Threading.Tasks;

namespace Footballista.Wasm.Client.Infra.ClientServices
{
	public class CurrentCultureService : ICurrentCultureService
	{
		private static string STORAGE_KEY = LocalStorageKeys.CurrentCulture;
		private readonly CultureInfo _defaultCulture = new CultureInfo("en-us");
		private readonly ILocalStorageService _localStorageService;
		private readonly ISyncLocalStorageService _syncLocalStorageService;

		public CurrentCultureService
		(
			ILocalStorageService localStorageService,
			ISyncLocalStorageService syncLocalStorageService
		)
		{
			_localStorageService = localStorageService;
			_syncLocalStorageService = syncLocalStorageService;
		}

		public async Task<string> GetCurrentCulture()
			=> await _localStorageService.GetItemAsync<string>(STORAGE_KEY);
		public async Task SetDefaultCurrentCultureAsync()
		{
			CultureInfo culture = _defaultCulture;
			string result = await GetCurrentCulture();
			if (result != null)
			{
				culture = new CultureInfo(result);
			}
			SetCurrentCultureForApplication(culture);
		}
		public async Task SetCurrentCultureAsync(string cultureCode)
		{
			var culture = new CultureInfo(cultureCode);
			SetCurrentCultureForApplication(culture);
			await _localStorageService.SetItemAsync(STORAGE_KEY, cultureCode);
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
			_syncLocalStorageService.SetItem(STORAGE_KEY, cultureCode);
		}
	}
}
