using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Footballista.BlazorServer
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var host = CreateHost(args);

			host.Run();
		}

		public static IHost CreateHost(string[] args)
		{
			return Host.CreateDefaultBuilder(args)
				.UseServiceProviderFactory(new AutofacServiceProviderFactory())
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				})
				.Build();
		}
	}
}
