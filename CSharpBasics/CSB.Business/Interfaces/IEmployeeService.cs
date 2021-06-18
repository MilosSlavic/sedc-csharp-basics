
﻿using CSB.Business.Enums;
using CSB.Repository.Entities;
using System.Collections.Generic;
﻿using CSB.Business.Models;
using System.Threading.Tasks;


namespace CSB.Business.Interfaces
{
    public interface IEmployeeService
    {
        Task<GetEmployeeDto> GetByIdAsync(int id);

        Task<IReadOnlyCollection<GetEmployeeDto>> GetAllAsync();

        Task<int> CreateAsync(CreateEmployeeDto employee);

        Task<bool> UpdateAsync(Employee employee);

        Task<bool> DeleteAsync(int id);

        Task<IReadOnlyCollection<Employee>> GetByNameAsync(string name);

        Task<IReadOnlyCollection<Employee>> GetOlderThanAsync(int age);

        Task<IReadOnlyCollection<Employee>> GetByGenderAsync(Gender gender);

        Task<IReadOnlyCollection<Employee>> GetByPositionAsync(string code);

        Task<IReadOnlyCollection<Address>> GetAddressByCityAsync(string city);

        Task<IReadOnlyCollection<Position>> GetPositionByCodeAsync(string code);

        //Task<IReadOnlyCollection<GetEmployeeDto>> GetAllAsync();

        //Task<int> CreateAsync(CreateEmployeeDto employee);
    }
}
