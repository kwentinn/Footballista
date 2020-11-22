using AutoMapper;
using Blazored.LocalStorage;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using Footballista.Wasm.Client.ClientServices;
using Footballista.Wasm.Client.Components.Services;
using Footballista.Wasm.Client.Domain.ClientServices;
using Footballista.Wasm.Client.Infra.ClientServices;
using Footballista.Wasm.Client.Infra.MappingProfiles;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
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
				.AddScoped(sp => new HttpClient
				{
					BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
				})
				.AddTransient<IPlayersClientService,PlayersClientService>()
				.AddTransient<IRankingsClientService, RankingsClientService>()
				.AddTransient<ICurrentCultureService, CurrentCultureService>()
				.AddTransient<IGameService, GameClientService>()
				.AddTransient<ICalendarService, CalendarService>()
				.AddTransient<CareerDateService>()
				.AddScoped<IToasterService, ToasterService>()
				.AddBlazoredLocalStorage(config =>
				{
					config.JsonSerializerOptions.AllowTrailingCommas = true;
					config.JsonSerializerOptions.WriteIndented = true;
				})
				.AddLocalization()
			;

			var configuration = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile<ClientMappingProfile>();
			});
			builder.Services.AddSingleton(configuration.CreateMapper());

			builder.RootComponents.Add<App>("#app");

			WebAssemblyHost host = builder.Build();

			await SetCurrentCulture(host);

			host.Services
			  .UseBootstrapProviders()
			  .UseFontAwesomeIcons();

			await host.RunAsync();
		}


		private static async Task SetCurrentCulture(WebAssemblyHost host)
		{
			var currentcultureService = host.Services.GetService<ICurrentCultureService>();
			await currentcultureService.SetDefaultCurrentCultureAsync();
		}
	}
}
