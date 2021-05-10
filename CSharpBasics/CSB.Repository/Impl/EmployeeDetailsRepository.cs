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
        private FileDbProvider _fileDb;
        public EmployeeDetailsRepository(FileDbProvider fileDb ) 
        {
            _fileDb = fileDb;
        }
        
        public int AddAddress(Address address)
        {
            var newId = _fileDb.Addresses.Max(x => x.Id);
            address.Id = newId + 1;
            _fileDb.Addresses.Add(address);
            _fileDb.Save();
            return address.Id;
        }

        public int AddPhone(Phone phone)
        {
            var maxId = _fileDb.Phones.Max(x => x.Id);
            phone.Id = maxId + 1;
            _fileDb.Phones.Add(phone);
            _fileDb.Save();
            return phone.Id;

        }

        public IReadOnlyList<Address> GetAddresses(int employeeId)
        {
            return _fileDb.Addresses.Where(x => x.EmployeeId == employeeId).ToList();
        }

        
     
        
    }
}
