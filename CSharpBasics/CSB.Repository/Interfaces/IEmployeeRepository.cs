using CSB.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSB.Repository.Interfaces
{
    public interface IEmployeeRepository
    {
        Employee GetById(int id);

        int Create(Employee employee);

        bool Update(Employee employee);

        bool Delete(int id);

        List<Employee> GetByName(string name);

        List<Employee> GetOlderThan(int age);

        List<Employee> GetByGender(short gender);

        List<Employee> GetByPosition(string code);

        List<Address> GetAddressByCity(string city);

        List<Employee> GetPositionByCode(string code);

        

    }
}
