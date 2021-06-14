using AutoMapper;
using CSB.Business.Enums;
using CSB.Business.Exceptions;
using CSB.Business.Interfaces;
using CSB.Business.Models;
using CSB.Repository.Entities;
using CSB.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSB.Business.Impl
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(
            IMapper mapper,
            IEmployeeRepository employeeRepository)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
        }

        public GetEmployeeDto GetById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var employee = _employeeRepository.GetById(id);
            if (employee is null)
            {
                throw new NotFoundException(nameof(Employee));
            }

            return _mapper.Map<GetEmployeeDto>(employee);
        }

        public IReadOnlyCollection<Employee> GetAll()
        {
            var employees = _employeeRepository.GetAll();
            if(employees.Any() == false)
            {
                throw new NotFoundException(nameof(Employee));
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
                throw new NotFoundException(nameof(Employee));
            }
            
            return employees;
        }
        
        public IReadOnlyCollection<Employee> GetByGender(Gender gender)
        {
            var employees = _employeeRepository.GetByGender((short)gender);
            if (employees.Any())
            {
                throw new NotFoundException(nameof(Employee));
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
                throw new NotFoundException(nameof(Employee));
            }

            return employees;
        }
        
        public IReadOnlyCollection<Address> GetAddressByCity(string city)
        {
            if (string.IsNullOrEmpty(city))
            {
                throw new ArgumentNullException(nameof(city));
            }

            var employees = _employeeRepository.GetAddressByCity(city);
            if (employees.Any())
            {
                throw new NotFoundException(nameof(Employee));
            }

            return employees;
        }
        
        public IReadOnlyCollection<Employee> GetPositionByCode(string code)
        {
            if (string.IsNullOrEmpty(code))
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
        
        public Task<int> CreateAsync(CreateEmployeeDto employee)
        {
            var entity = _mapper.Map<Employee>(employee);
            return _employeeRepository.CreateAsync(entity);
        }

        public async Task<IReadOnlyCollection<GetEmployeeDto>> GetAllAsync()
        {
            var result = await _employeeRepository.GetAllAsync();
            return _mapper.Map<IReadOnlyCollection<GetEmployeeDto>>(result);
        }
    }
}
