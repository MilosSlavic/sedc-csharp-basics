﻿using CSB.Business.Interfaces;
using CSB.Repository.Entities;
using CSB.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSB.Business.Impl
{
    class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
            this._addressRepository = addressRepository;
        }


        public async Task<int> CreateAsync(Address address)
        {
            if (address is null)
            {
                throw new ArgumentException();
            }
            return await _addressRepository.CreateAsync(address);
        }

        public async Task<bool> DeleteAsync(int employeeId)
        {
            if (employeeId <= 0)
            {
                throw new ArgumentException();
            }
            return await _addressRepository.DeleteAsync(employeeId);
        }

        public async Task<IReadOnlyCollection<Address>> GetAllAsync()
        {
            return await _addressRepository.GetAllAsync();
        }

        public Task<IReadOnlyCollection<Address>> GetByEmployeeIdAsync(int employeeId)
        {
            if (employeeId <= 0)
            {
                throw new ArgumentException(nameof(employeeId));
            }

            return _addressRepository.GetByEmployeeIdAsync(employeeId);
        }

        public async Task<bool> UpdateAsync(Address address)
        {
            if (address is null)
            {
                throw new ArgumentException();
            }
            return await _addressRepository.UpdateAsync(address);
        }
    }
}
