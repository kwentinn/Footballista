using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace Footballista.Wasm.Client.ClientServices
{
	public class LocalStorageService
	{
		private readonly IJSRuntime _jSRuntime;

		public LocalStorageService(IJSRuntime jSRuntime)
		{
			_jSRuntime = jSRuntime;
		}

		public async Task<string> GetAsync(string key)
			=> await _jSRuntime.InvokeAsync<string>($"{key}.get");

		public async Task SetAsync(string key, string value)
		{
			await _jSRuntime.InvokeVoidAsync($"{key}.set", value);
		}

		public void Set(string key, string value)
		{
			if (string.IsNullOrWhiteSpace(key))
			{
				throw new System.ArgumentException("Key must be provided", nameof(key));
			}

			var js = (IJSInProcessRuntime)_jSRuntime;
			js.InvokeVoidAsync($"{key}.set", value);
		}
	}
}
