using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSB.Repository.Entities;
using CSB.Repository.Interfaces;

namespace CSB.Repository.Impl
{
    public class EmployeeDetailsRepository : IEmployeeDetailsRepository
    {
        public int AddAddress(Address address)
        {
            throw new NotImplementedException();
        }

        public int AddPhone(Phone phone)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<Address> GetAddresses(int employeeId)
        {
            throw new NotImplementedException();
        }
    }
}
