using CSB.Repository.Entities;
using CSB.Repository.GenericRepo;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSB.Business.Interfaces
{
    public interface IPositionService
    {
        Task<int> CreateAsync(Position item);

        Task<bool> UpdateAsync(Position item);

        Task<bool> DeleteAsync(int id);

        Task<Position> GetByIdAsync(int id);

        Task<IReadOnlyCollection<Position>> GetAllAsync();
    }
}
