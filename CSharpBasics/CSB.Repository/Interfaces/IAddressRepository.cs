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
        int AddAddress(Address address);

        IReadOnlyList<Address> GetAddresses(int employeeId);
    }
}
