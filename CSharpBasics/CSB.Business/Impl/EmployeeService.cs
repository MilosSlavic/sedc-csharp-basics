using AutoMapper;
using CSB.Business.Enums;
using CSB.Business.Exceptions;
using CSB.Business.Interfaces;
using CSB.Business.Models;
using CSB.Repository.Entities;
using CSB.Repository.Interfaces;
using System;
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
                throw new ArgumentException(nameof(id));
            }

            var employee = _employeeRepository.GetById(id);
            if (employee is null)
            {
                throw new NotFoundException(nameof(Employee));
            }

            return _mapper.Map<GetEmployeeDto>(employee);
        }

        public Task<int> CreateAsync(CreateEmployeeDto employee)
        {
            var entity = _mapper.Map<Employee>(employee);
            return _employeeRepository.CreateAsync(entity);
        }
    }
}
