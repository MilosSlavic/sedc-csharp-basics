using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CSB.Business.Interfaces;
using CSB.Repository.Entities;
using CSB.Repository.Interfaces;

namespace CSB.Business.Impl

{
    public class PhoneService : IPhoneService
    {
        private readonly IPhoneRepository _phoneRepository;

        public PhoneService(IPhoneRepository phoneRepository)
        {
            this._phoneRepository = phoneRepository;
        }
        
        public async Task<int> CreateAsync(Phone phone)
        {
            if (phone is null)
            {
                throw new ArgumentNullException();
            }

            return await _phoneRepository.CreateAsync(phone);
        }

        public async Task<bool> UpdateAsync(Phone phone)
        {
            if (phone is null)
            {
                throw new ArgumentNullException();
            }
            return await _phoneRepository.UpdateAsync(phone);
        }

        public async Task<bool> DeleteAsync(int id)
        {

            if (id <= 0)
            {
                throw new ArgumentException();
            }
            return await _phoneRepository.DeleteAsync(id);
           
        }

        public async Task IReadOnlyCollectionAsync<Phone>GetAll()
        {
            return await _phoneRepository.GetAllAsync();
        }


        public async Task <Phone> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException();
            }
            return await _phoneRepository.GetByIdAsync(id);
        }
    }
}
