using CSB.Business.Exceptions;
using CSB.Business.Interfaces;
using CSB.Repository.Entities;
using CSB.Repository.Interfaces;
using System;
using System.Collections.Generic;

namespace CSB.Business.Impl
{
    internal class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public Employee GetById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException(nameof(id));
            }

            var employee = _employeeRepository.GetById(id);
            if(employee is null)
            {
                throw new NotFoundException(nameof(Employee));
            }

            return employee;
        }

        /*  public Employee GetById(int id)
        {
            return _fileDb.Employees.FirstOrDefault(x => x.Id == id);
        }*/

        // public IReadOnlyCollection<T> GetAll() nema argumente tako da nemam na sta da trazim argument exception?
        //int Create(Employee employee);
        public int Create(Employee employee)
        {
            if (employee is null)
            {
                throw new ArgumentException(nameof(employee));
            }

            return _employeeRepository.Create(employee);
        }
        //bool Update(Employee employee);
        public bool Update(Employee employee)
        {
            if (employee is null)
            {
                throw new ArgumentException(nameof(employee));
            }

            return _employeeRepository.Update(employee);
        }

        //bool Delete(int id);
        public bool Delete(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException(nameof(id));
            }

            return _employeeRepository.Delete(id);
        }

        //List<Employee> GetByName(string name);
        public List<Employee> GetByName(string name)
        {
            if(name.Length == 0)
            {
                throw new ArgumentException(nameof(name));
            }

            var employees = _employeeRepository.GetByName(name);
            if(employees.Count == 0)
            {
                throw new NotFoundException(nameof(List<Employee>));
            }

            return employees;
        }

        //List<Employee> GetOlderThan(int age);
        public List<Employee> GetOlderThan(int age)
        {

            var employees = _employeeRepository.GetOlderThan(age);
            if (employees.Count == 0)
            {
                throw new NotFoundException(nameof(List<Employee>));
            }
            
            return employees;
        }
        //List<Employee> GetByGender(short gender);
        public List<Employee> GetByGender(short gender)
        {
            var employees = _employeeRepository.GetByGender(gender);
            if (employees.Count == 0)
            {
                throw new NotFoundException(nameof(List<Employee>));
            }

            return employees;
        }
        //List<Employee> GetByPosition(string code);
        public List<Employee> GetByPosition(string code)
        {
            if (code.Length == 0)
            {
                throw new ArgumentException(nameof(code));
            }

            var employees = _employeeRepository.GetByPosition(code);
            if (employees.Count == 0)
            {
                throw new NotFoundException(nameof(List<Employee>));
            }

            return employees;
        }
        //List<Address> GetAddressByCity(string city);
        public List<Address> GetAddressByCity(string city)
        {
            if (city.Length == 0)
            {
                throw new ArgumentException(nameof(city));
            }

            var employees = _employeeRepository.GetAddressByCity(city);
            if (employees.Count == 0)
            {
                throw new NotFoundException(nameof(List<Employee>));
            }

            return employees;
        }
        //List<Employee> GetPositionByCode(string code);
        public List<Employee> GetPositionByCode(string code)
        {
            if (code.Length == 0)
            {
                throw new ArgumentException(nameof(code));
            }

            var employees = _employeeRepository.GetPositionByCode(code);
            if (employees.Count == 0)
            {
                throw new NotFoundException(nameof(List<Employee>));
            }

            return employees;
        }
    }
}
