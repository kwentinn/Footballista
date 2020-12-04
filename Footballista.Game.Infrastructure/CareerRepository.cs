using Footballista.Game.Domain;
using Footballista.Game.Domain.Careers;
using Footballista.Game.Infrastructure.Entities;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Footballista.Game.Infrastructure
{
	public class CareerRepository : ICareerRepository
	{
		private const string PATH = "c:\\temp\\careers.json";

		private readonly JsonSerializerOptions _options = new JsonSerializerOptions()
		{
			AllowTrailingCommas = true,
			IgnoreReadOnlyFields = true,
			MaxDepth = 30,
			NumberHandling = System.Text.Json.Serialization.JsonNumberHandling.Strict,
			PropertyNameCaseInsensitive = true,
			WriteIndented = false
		};

		public async Task<Career> GetByIdAsync(CareerId id)
		{
			using FileStream filestream = new FileStream(PATH, FileMode.Open);

			CareerDb careerDb = await JsonSerializer.DeserializeAsync<CareerDb>(filestream);

			return careerDb.ToDomain();
		}

		public async Task SaveAsync(Career career)
		{
			CareerDb careerDb = career.ToDb();

			using Stream stream = File.Create(PATH);
			await JsonSerializer.SerializeAsync(stream, careerDb, this._options);
		}
	}
}
