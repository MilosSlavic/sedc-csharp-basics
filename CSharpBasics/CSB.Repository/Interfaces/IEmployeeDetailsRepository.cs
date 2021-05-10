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
        int AddPhone(Phone phone);
        int AddPosition(Position position);

        Position GetPosition(int employeeId);

        IReadOnlyList<Address> GetAddresses(int employeeId);
        IReadOnlyList<Phone> GetPhones(int employeeId);
    }
}
