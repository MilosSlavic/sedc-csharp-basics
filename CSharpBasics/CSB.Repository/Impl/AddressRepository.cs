using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSB.Repository.Entities;
using CSB.Repository.Interfaces;

namespace CSB.Repository.Impl
{
    internal class AddressRepository : IAddressRepository
    {
        private FileDbProvider _fileDb;

        public int AddAddress(Address address)
        {
            var newId = _fileDb.Addresses.Max(x => x.Id);
            address.Id = newId + 1;
            _fileDb.Addresses.Add(address);
            _fileDb.Save();
            return address.Id;
        }

        public IReadOnlyList<Address> GetAddresses(int employeeId)
        {
            return _fileDb.Addresses.Where(x => x.EmployeeId == employeeId).ToList();
        }
    }
}
