using System.Collections.Generic;
using System.Threading.Tasks;
using CSB.Repository.Entities;

namespace CSB.Business.Interfaces
{
    public interface IPhoneService
    {
        Task<int> CreateAsync(Phone phone);

        Task<bool> UpdateAsync(Phone phone);

        Task<bool> DeleteAsync(int id);

        Task<Phone> GetByIdAsync(int id);

        Task<IReadOnlyCollection<Phone>> GetAllAsync();
    }
}
