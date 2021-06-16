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
        public Task<int> CreateAsync(Phone phone)
        {
            if (phone is null)
            {
                throw new ArgumentNullException();
            }
            
            return _phoneRepository.CreateAsync(phone);
        }

        public Task<bool> UpdateAsync(Phone phone)
        {
            if (phone is null)
            {
                throw new ArgumentNullException();
            }
            return _phoneRepository.UpdateAsync(phone);
        }

        public Task<bool> DeleteAsync(int id)
        {
            
            if (id <= 0)
            {
                throw new ArgumentException();
            }
            return _phoneRepository.DeleteAsync(id);
           
        }

        public Task<IReadOnlyCollection<Phone>> GetAllAsync()
        {
            return _phoneRepository.GetAllAsync();
        }


        public Task<Phone> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException();
            }
            return _phoneRepository.GetByIdAsync(id);
        }
    }
}
