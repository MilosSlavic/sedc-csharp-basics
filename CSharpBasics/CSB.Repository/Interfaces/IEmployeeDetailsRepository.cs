using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSB.Repository.Entities;

namespace CSB.Repository.Interfaces
{
    interface IEmployeeDetailsRepository
    {
        int AddAddress(Address address);

        IReadOnlyList<Address> GetAddresses(int employeeId);

        
    }
}
