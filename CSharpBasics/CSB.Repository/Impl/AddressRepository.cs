using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSB.Repository.Entities;
using CSB.Repository.Interfaces;
using CSB.Repository.GenericRepo;

namespace CSB.Repository.Impl
{
    internal class AddressRepository : GenericRepository<Address>, IAddressRepository
    {
        public AddressRepository(CbsDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        private readonly CbsDbContext dbContext;

        public IReadOnlyList<Address> GetAddresses(int employeeId)
        {
            return dbContext.Addresses.Where(x => x.EmployeeId == employeeId).ToList();
        }
    }
}
