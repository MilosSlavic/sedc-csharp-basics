using CSB.Repository.Entities;
using CSB.Repository.GenericRepo;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSB.Repository.Interfaces
{
    public interface IAddressRepository : IGenericRepository<Address>
    {
        Task<IReadOnlyCollection<Address>> GetByEmployeeIdAsync(int employeeId);

        Task<IReadOnlyCollection<Address>> GetAddressByCityAsync(string city);
    }
}
