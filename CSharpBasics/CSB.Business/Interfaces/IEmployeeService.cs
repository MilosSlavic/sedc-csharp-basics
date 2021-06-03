using CSB.Repository.Entities;
using System.Collections.Generic;

namespace CSB.Business.Interfaces
{
    public interface IEmployeeService
    {
        Employee GetById(int id);

        IReadOnlyCollection<Employee> GetAll();

        int Create(Employee employee);

        bool Update(Employee employee);

        bool Delete(int id);

        IReadOnlyCollection<Employee> GetByName(string name);

        IReadOnlyCollection<Employee> GetOlderThan(int age);

        IReadOnlyCollection<Employee> GetByGender(short gender);

        IReadOnlyCollection<Employee> GetByPosition(string code);

        IReadOnlyCollection<Address> GetAddressByCity(string city);

        IReadOnlyCollection<Employee> GetPositionByCode(string code);
    }
}
