using Footballista.Game.Domain;
using Footballista.Game.Domain.Careers;
using Footballista.Game.Infrastructure.Entities;
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
            var careerDb = new CareerDb
            {
                Id = career.Id,
                CurrentDate = new DateDb
                {
                    Year = career.CurrentDate.Year,
                    Month = career.CurrentDate.Month,
                    Day = career.CurrentDate.Day
                },
                Name = career.Name,
                Club = new ClubDb()
                {
                    Id = career.Club.Id,
                    Name = career.Club.Name,
                }, 
                Manager = new ManagerDb
                {
                    Id =  career.Manager.Id,
                    Firstname =  career.Manager.Firstname,
                    Lastname =  career.Manager.Lastname,
                }
            };

            var path = "c:\\temp\\careers.json";
            using Stream stream = File.Create(path);
            await JsonSerializer.SerializeAsync(stream, careerDb, options);
        }
    }
}
