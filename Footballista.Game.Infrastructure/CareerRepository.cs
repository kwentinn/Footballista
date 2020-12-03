using Footballista.Game.Domain;
using Footballista.Game.Domain.Careers;
using Footballista.Game.Domain.Clubs;
using Footballista.Game.Domain.Clubs.Teams;
using Footballista.Game.Domain.Competitions;
using Footballista.Game.Infrastructure.Entities;
using Itenso.TimePeriod;
using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Footballista.Game.Infrastructure
{
    public class CareerRepository : ICareerRepository
    {
        private readonly JsonSerializerOptions options = new JsonSerializerOptions()
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
            throw new NotImplementedException();
        }

        public async Task SaveAsync(Career career)
        {
            CareerDb careerDb = career.ToDb();

            string path = "c:\\temp\\careers.json";
            using Stream stream = File.Create(path);
            await JsonSerializer.SerializeAsync(stream, careerDb, this.options);
        }
    }
}
