using Microsoft.AspNetCore.Builder;

namespace Footballista.Wasm.Server.Configuration
{
	public static class IApplicationBuilderExtensions
	{
		public static IApplicationBuilder UseLocalizationMiddleware(this IApplicationBuilder app)
		{
			string[] supportedCultures = new[] { "en-US", "fr" };

			RequestLocalizationOptions localizationOptions = new RequestLocalizationOptions()
				.SetDefaultCulture(supportedCultures[0])
				.AddSupportedCultures(supportedCultures)
				.AddSupportedUICultures(supportedCultures);

			return app.UseRequestLocalization(localizationOptions);
		}
	}
}
