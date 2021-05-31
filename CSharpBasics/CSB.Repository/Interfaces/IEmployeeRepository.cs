using CSB.Repository.Entities;
using CSB.Repository.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSB.Repository.Interfaces
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        List<Employee> GetByName(string name);

        List<Employee> GetOlderThan(int age);

        List<Employee> GetByGender(short gender);

        List<Employee> GetByPosition(string code);

        List<Address> GetAddressByCity(string city);

        List<Employee> GetPositionByCode(string code);



    }
}
