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
        //public int Create (Phone phone)
        {
            if (phone is null)
            {
                throw new ArgumentNullException();
            }

            return await _phoneRepository.Create(phone);
        }

        public async Task<bool> UpdateAsync(Phone phone)
        //public int Update (Phone phone)
        {
            if (phone is null)
            {
                throw new ArgumentNullException();
            }
            return await _phoneRepository.Update(phone);
        }

        public async Task<bool> DeleteAsync(int id)
        //public int Delete (int id)
        {

            if (id <= 0)
            {
                throw new ArgumentException();
            }
            return await _phoneRepository.Delete(id);
           
        }

        public async Task IReadOnlyCollectionAsync<Phone>GetAll()
        //public IReadOnlyCollection<Phone> GetAll()
        {
            return await _phoneRepository.GetAll();
        }


        public async Task <Phone> GetByIdAsync(int id)
        //public Phone GetById (int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException();
            }
            return await _phoneRepository.GetById(id);
        }
    }
}
