using CSB.Repository.Entities;
using CSB.Repository.Interfaces;
using CSB.Repository.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CSB.Repository.Impl
{

    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        private readonly CbsDbContext dbContext;
        public EmployeeRepository(CbsDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task<IReadOnlyCollection<Employee>> GetByNameAsync(string name)
        {
            return await dbContext.Employees.Where(x => x.FirstName == name).ToListAsync();
                   
        }


        public async Task<IReadOnlyCollection<Employee>> GetOlderThanAsync(int age)
        {
            return await dbContext.Employees.Where(x => Math.Abs(x.DateOfBirth.Subtract(DateTime.Today).Days) / 365 > age).ToListAsync();
        }
        public async Task<IReadOnlyCollection<Employee>> GetByGenderAsync(short gender)
        {
            return await dbContext.Employees.Where(x => x.Gender == gender).ToListAsync();
        }

        public async Task<IReadOnlyCollection<Employee>> GetByPositionAsync(string code)
        {
            return await dbContext.Employees.Where(x => x.Position != null && x.Position.Code == code).ToListAsync();
        }

        public async Task<IReadOnlyCollection<Address>> GetAddressByCityAsync(string city)
        {
           IReadOnlyCollection<Address> addressesList =await dbContext.Addresses.Where(x => x.City == city).ToListAsync();

            return addressesList;
        }

        public async Task<IReadOnlyCollection<Position>> GetPositionByCodeAsync(string code)
        {
            IReadOnlyCollection<Position> pos = await dbContext.Positions.Where(x => x.Code == code).ToListAsync();

            return pos;
        }


    }
}

