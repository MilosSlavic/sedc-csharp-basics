using System.Collections.Generic;
using System.Threading.Tasks;
using CSB.Repository.Entities;
using CSB.Repository.GenericRepo;

namespace CSB.Repository.Interfaces
{
    public interface IPhoneRepository : IGenericRepository<Phone>
    {
        List<Phone> GetByName(string name);
        Task<int> CreateAsync(Phone phone);
        Task<bool> UpdateAsync(Phone phone);
        Task<bool> DeleteAsync(int id);
        Task <IReadOnlyCollection<Phone>> GetAllAsync();
        Task<Phone> GetByIdAsync(int id);
    }
}
