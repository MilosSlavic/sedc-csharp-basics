using CSB.Repository.Entities;
using CSB.Repository.GenericRepo;
using CSB.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSB.Repository.Impl
{
    internal class AddressRepository : GenericRepository<Address>, IAddressRepository
    {
        public AddressRepository(CbsDbContext dbContext) : base(dbContext)
        {
        }

        private readonly CbsDbContext dbContext;

        public async Task<IReadOnlyCollection<Address>> GetByEmployeeIdAsync(int employeeId)
        {
            return await dbContext.Addresses.Where(x => x.EmployeeId == employeeId).ToListAsync();
        }

        public async Task<IReadOnlyCollection<Address>> GetAddressByCityAsync(string city)
        {
            IReadOnlyCollection<Address> addressesList = await dbContext.Addresses
                .Where(x => x.City == city)
                .ToListAsync();

            return addressesList;
        }
    }
}
