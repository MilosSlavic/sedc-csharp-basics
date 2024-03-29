﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CSB.Repository.Entities;
using CSB.Repository.GenericRepo;

namespace CSB.Business.Interfaces
{
    interface IAddressService
    {
        Task<int> CreateAsync(Address address);
        Task<bool> DeleteAsync(int employeeId);
        Task<bool> UpdateAsync(Address address);
        Task<IReadOnlyCollection<Address>> GetAllAsync();
        Task<IReadOnlyCollection<Address>> GetByEmployeeIdAsync(int employeeId);
    }
}
