using CSB.Business.Exceptions;
using CSB.Business.Interfaces;
using CSB.Repository.Entities;
using CSB.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

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
                throw new ArgumentNullException(nameof(id));
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

        public IReadOnlyCollection<Employee> GetAll()
        {
            var employees = _employeeRepository.GetAll();
            if(employees.Any() == false)
            {
                throw new NotFoundException(nameof(IReadOnlyCollection<Employee>));
            }
            return employees;
        }
        public int Create(Employee employee)
        {
            if (employee is null)
            {
                throw new ArgumentNullException(nameof(employee));
            }

            return _employeeRepository.Create(employee);
        }
        
        public bool Update(Employee employee)
        {
            if (employee is null)
            {
                throw new ArgumentNullException(nameof(employee));
            }

            return _employeeRepository.Update(employee);
        }

        
        public bool Delete(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException(nameof(id));
            }

            return _employeeRepository.Delete(id);
        }

        
        public IReadOnlyCollection<Employee> GetByName(string name)
        {
            if(String.IsNullOrEmpty(name))
            {
                throw new ArgumentException(nameof(name));
            }

            var employees = _employeeRepository.GetByName(name);
            if(employees.Any())
            {
                throw new NotFoundException(nameof(List<Employee>));
            }

            return employees;
        }

        
        public IReadOnlyCollection<Employee> GetOlderThan(int age)
        {

            var employees = _employeeRepository.GetOlderThan(age);
            if (employees.Any())
            {
                throw new NotFoundException(nameof(List<Employee>));
            }
            
            return employees;
        }
        
        public IReadOnlyCollection<Employee> GetByGender(short gender)
        {
            var employees = _employeeRepository.GetByGender(gender);
            if (employees.Any())
            {
                throw new NotFoundException(nameof(List<Employee>));
            }

            return employees;
        }
        
        public IReadOnlyCollection<Employee> GetByPosition(string code)
        {
            if (String.IsNullOrEmpty(code))
            {
                throw new ArgumentNullException(nameof(code));
            }

            var employees = _employeeRepository.GetByPosition(code);
            if (employees.Any())
            {
                throw new NotFoundException(nameof(List<Employee>));
            }

            return employees;
        }
        
        public IReadOnlyCollection<Address> GetAddressByCity(string city)
        {
            if (String.IsNullOrEmpty(city))
            {
                throw new ArgumentNullException(nameof(city));
            }

            var employees = _employeeRepository.GetAddressByCity(city);
            if (employees.Any())
            {
                throw new NotFoundException(nameof(List<Employee>));
            }

            return employees;
        }
        
        public IReadOnlyCollection<Employee> GetPositionByCode(string code)
        {
            if (String.IsNullOrEmpty(code))
            {
                throw new ArgumentNullException(nameof(code));
            }

            var employees = _employeeRepository.GetPositionByCode(code);
            if (employees.Any())
            {
                throw new NotFoundException(nameof(List<Employee>));
            }

            return employees;
        }
    }
}
