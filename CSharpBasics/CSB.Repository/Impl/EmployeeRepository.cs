using CSB.Repository.Entities;
using CSB.Repository.Interfaces;
using CSB.Repository.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSB.Repository.Impl
{

    internal class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        private readonly CbsDbContext dbContext;
        public EmployeeRepository(CbsDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }


        public List<Employee> GetByName(string name)
        {
            return dbContext.Employees.Where(x => x.FirstName == name).ToList();
        }


        public List<Employee> GetOlderThan(int age)
        {
            return dbContext.Employees.Where(x => Math.Abs(x.DateOfBirth.Subtract(DateTime.Today).Days) / 365 > age).ToList();
        }
        public List<Employee> GetByGender(short gender)
        {
            return dbContext.Employees.Where(x => x.Gender == gender).ToList();
        }

        public List<Employee> GetByPosition(string code)
        {
            return dbContext.Employees.Where(x => x.Position != null && x.Position.Code == code).ToList();
        }

        public List<Address> GetAddressByCity(string city)
        {
            List<Address> addressesList = dbContext.Addresses.Where(x => x.City == city).ToList();

            return addressesList;
        }

        public List<Employee> GetPositionByCode(string code)
        {
            List<Employee> pos = dbContext.Employees.Where(x => x.Position.Code == code).ToList();

            return pos;
        }


    }
}

