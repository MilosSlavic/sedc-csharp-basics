using CSB.Business.Exceptions;
using CSB.Business.Interfaces;
using CSB.Repository.Entities;
using CSB.Repository.Interfaces;
using System;

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
    }
}
