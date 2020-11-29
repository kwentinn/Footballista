using Footballista.Game.Domain;
using Footballista.Game.Domain.Careers;
using System;
using System.Threading.Tasks;

namespace Footballista.Game.Infrastructure
{
    public class CareerRepository : ICareerRepository
    {
        public async Task<Career> GetByIdAsync(CareerId id)
        {
            throw new NotImplementedException();
        }

        public async Task SaveAsync(Career career)
        {
            throw new NotImplementedException();
        }
    }
}
