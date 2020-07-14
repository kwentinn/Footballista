using System.Threading.Tasks;

namespace Footballista.Wasm.Client.Domain.ClientServices
{
	public interface ICurrentCultureService
	{
		Task<string> GetCurrentCulture();
		Task SetDefaultCurrentCultureAsync();
		Task SetCurrentCultureAsync(string cultureCode);
		void SetCurrentCulture(string cultureCode);
	}
}
