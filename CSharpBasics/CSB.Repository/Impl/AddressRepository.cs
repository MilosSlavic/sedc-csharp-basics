using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSB.Repository.Entities;
using CSB.Repository.Interfaces;
using CSB.Repository.GenericRepo;
using Microsoft.EntityFrameworkCore;

namespace CSB.Repository.Impl
{
    internal class AddressRepository : GenericRepository<Address>, IAddressRepository
    {
        public AddressRepository(CbsDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        private readonly CbsDbContext dbContext;

        public async Task<IReadOnlyList<Address>> GetAddressesAsync(int employeeId)
        {
            return await dbContext.Addresses.Where(x => x.EmployeeId == employeeId).ToListAsync();
        }
    }
}
