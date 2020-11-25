using Autofac;
using Footballista.Wasm.Server.Configuration;
using Footballista.Wasm.Server.Configuration.AutofacModules;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Footballista.Wasm.Server
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllersWithViews();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			//app.UseResponseCompression(); 

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseWebAssemblyDebugging();
			}
			else
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app
				.UseHttpsRedirection()
				.UseBlazorFrameworkFiles()
				.UseStaticFiles()
				.UseLocalizationMiddleware()
				.UseRouting()
				.UseEndpoints(endpoints =>
				{
					endpoints.MapControllers();
					endpoints.MapFallbackToFile("index.html");
				});
		}

		/// <summary>
		/// Called automatically by AutoFac
		/// </summary>
		/// <param name="builder"></param>
		public void ConfigureContainer(ContainerBuilder builder)
		{
			builder.RegisterModule(new PlayersModule());
			builder.RegisterModule(new BlazorWasmServerModule());
			builder.RegisterModule(new MappersModule());
			builder.RegisterModule(new MediatRModule());
		}
	}
}
