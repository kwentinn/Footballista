using Blazored.LocalStorage;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using Footballista.Wasm.Client.ClientServices;
using Footballista.Wasm.Client.LocalStorage;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;

namespace Footballista.Wasm.Client
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebAssemblyHostBuilder.CreateDefault(args);

			builder.Services
				.AddBlazorise(o => { o.ChangeTextOnKeyPress = true; })
				.AddBootstrapProviders()
				.AddFontAwesomeIcons()
				.AddSingleton(new HttpClient
				{
					BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
				})
				.AddTransient(typeof(IPlayersClientService), typeof(PlayersClientService))
				.AddTransient(typeof(IRankingsClientService), typeof(RankingsClientService))
				.AddTransient(typeof(GameService))
				.AddTransient(typeof(CalendarService))
				.AddTransient(typeof(CareerDateService))
				.AddBlazoredLocalStorage(config =>
				{
					config.JsonSerializerOptions.AllowTrailingCommas = true;
					//config.JsonSerializerOptions.
					config.JsonSerializerOptions.WriteIndented = true;
				})
				.AddLocalization()
			;

			builder.RootComponents.Add<App>("app");

			WebAssemblyHost host = builder.Build();

			await SetCurrentCulture(host);

			host.Services
			  .UseBootstrapProviders()
			  .UseFontAwesomeIcons();

			await host.RunAsync();
		}


		private static async Task SetCurrentCulture(WebAssemblyHost host)
		{
			CultureInfo culture = new CultureInfo("en-us");

			ILocalStorageService localStorageService = host.Services.GetService<ILocalStorageService>();
			string result = await localStorageService.GetItemAsync<string>(LocalStorageKeys.CurrentCulture);
			if (result != null)
			{
				culture = new CultureInfo(result);
			}

			CultureInfo.DefaultThreadCurrentCulture = culture;
			CultureInfo.DefaultThreadCurrentUICulture = culture;
		}
	}
}
