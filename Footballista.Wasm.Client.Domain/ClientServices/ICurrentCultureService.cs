using System.Threading.Tasks;

namespace Footballista.Wasm.Client.Domain.ClientServices
{
	public interface ICurrentCultureService
	{
		Task<string> GetCurrentCultureFromLocalStorage();
		Task SetDefaultCurrentCultureAsync();
		Task SetCurrentCultureAsync(string cultureCode);
		void SetCurrentCulture(string cultureCode);
	}
}
