using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using Footballista.Wasm.Client.ClientServices;
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
			  .AddBlazorise(options =>
			  {
				  options.ChangeTextOnKeyPress = true;
			  })
			  .AddBootstrapProviders()
			  .AddFontAwesomeIcons();

			builder.Services
				.AddSingleton(new HttpClient
				{
					BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
				})
				.AddTransient(typeof(IPlayersClientService), typeof(PlayersClientService))
				.AddTransient(typeof(IRankingsClientService), typeof(RankingsClientService))
			;

			builder.RootComponents.Add<App>("app");

			var host = builder.Build();

			host.Services
			  .UseBootstrapProviders()
			  .UseFontAwesomeIcons();

			await host.RunAsync();
		}
	}
}
