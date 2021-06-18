using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSB.Repository.Entities;
using CSB.Repository.GenericRepo;

namespace CSB.Repository.Interfaces
{
    public interface IAddressRepository : IGenericRepository<Address>
    {
        Task<IReadOnlyList<Address>> GetAddressesAsync(int employeeId);
        Task<Address> GetAddressesByIdAsync(int employeeId);
    }
}
