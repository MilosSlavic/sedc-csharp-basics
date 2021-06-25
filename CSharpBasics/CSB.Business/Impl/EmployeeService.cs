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

        public async Task<GetEmployeeDto> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException(nameof(id));
            }

            var employee = await _employeeRepository.GetByIdAsync(id);
            if (employee is null)
            {
                throw new NotFoundException(nameof(Employee));
            }

            return _mapper.Map<GetEmployeeDto>(employee);
        }

        public async Task<IReadOnlyCollection<GetEmployeeDto>> GetAllAsync()
        {
            var employees = await _employeeRepository.GetAllAsync();
            if (employees.Any() == false)
            {
                throw new NotFoundException(nameof(Employee));
            }

            return _mapper.Map<IReadOnlyCollection<GetEmployeeDto>>(employees);
        }
        /*public async Task<IReadOnlyCollection<GetEmployeeDto>> GetAllAsync()
        {
            var result = await _employeeRepository.GetAllAsync();
            return _mapper.Map<IReadOnlyCollection<GetEmployeeDto>>(result);
        }*/
        /*public Task<int> CreateAsync(CreateEmployeeDto employee)
        {
            var entity = _mapper.Map<Employee>(employee);
            return _employeeRepository.CreateAsync(entity);
        }*/
        public async Task<int> CreateAsync(CreateEmployeeDto employee)
        {
            if (employee is null)
            {
                throw new ArgumentNullException(nameof(employee));
            }

            var entity = _mapper.Map<Employee>(employee);
            return await _employeeRepository.CreateAsync(entity);
        }

        public async Task<bool> UpdateAsync(Employee employee)
        {
            if (employee is null)
            {
                throw new ArgumentNullException(nameof(employee));
            }

            return await _employeeRepository.UpdateAsync(employee);
        }


        public async Task<bool> DeleteAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException(nameof(id));
            }

            await GetByIdAsync(id);
            return await _employeeRepository.DeleteAsync(id);
        }


        public async Task<IReadOnlyCollection<Employee>> GetByNameAsync(string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentException(nameof(name));
            }

            var employees = await _employeeRepository.GetByNameAsync(name);
            if (employees.Any())
            {
                throw new NotFoundException(nameof(List<Employee>));
            }

            return employees;
        }


        public async Task<IReadOnlyCollection<Employee>> GetOlderThanAsync(int age)
        {

            var employees = await _employeeRepository.GetOlderThanAsync(age);
            if (employees.Any())
            {
                throw new NotFoundException(nameof(Employee));
            }

            return employees;
        }

        public async Task<IReadOnlyCollection<Employee>> GetByGenderAsync(Gender gender)
        {
            var employees = await _employeeRepository.GetByGenderAsync((short)gender);
            if (employees.Any())
            {
                throw new NotFoundException(nameof(Employee));
            }

            return employees;
        }

        public async Task<IReadOnlyCollection<Employee>> GetByPositionAsync(string code)
        {
            if (String.IsNullOrEmpty(code))
            {
                throw new ArgumentNullException(nameof(code));
            }

            var employees = await _employeeRepository.GetByPositionAsync(code);
            if (employees.Any())
            {
                throw new NotFoundException(nameof(Employee));
            }

            return employees;
        }

        public async Task<IReadOnlyCollection<Position>> GetPositionByCodeAsync(string code)
        {
            if (string.IsNullOrEmpty(code))
            {
                throw new ArgumentNullException(nameof(code));
            }

            var employees = await _employeeRepository.GetPositionByCodeAsync(code);
            if (employees.Any())
            {
                throw new NotFoundException(nameof(List<Employee>));
            }

            return employees;
        }




    }
}
