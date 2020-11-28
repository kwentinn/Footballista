using Footballista.Game.Domain.Careers;
using System.Threading.Tasks;

namespace Footballista.Game.Domain
{
    public interface ICareerRepository
    {
        Task<Career> GetByIdAsync(CareerId id);

        Task SaveAsync(Career career);
    }
}
