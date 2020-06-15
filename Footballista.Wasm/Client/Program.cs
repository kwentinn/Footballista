using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using Footballista.Wasm.Client.ClientServices;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
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

			IJSRuntime jsInterop = host.Services.GetRequiredService<IJSRuntime>();
			string result = await jsInterop.InvokeAsync<string>("blazorCulture.get");
			if (result != null)
			{
				culture = new CultureInfo(result);
			}

			CultureInfo.DefaultThreadCurrentCulture = culture;
			CultureInfo.DefaultThreadCurrentUICulture = culture;
		}
	}
}
