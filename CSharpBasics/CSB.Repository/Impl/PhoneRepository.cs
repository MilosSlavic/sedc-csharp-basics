using System;
using CSB.Repository.Entities;
using CSB.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using CSB.Repository.GenericRepo;
using System.Threading.Tasks;

namespace CSB.Repository.Impl
{
    public class PhoneRepository : GenericRepository<Phone>, IPhoneRepository
    {
        public PhoneRepository(CbsDbContext dbContext) : base(dbContext)
        {
        }

        public Task<int> CreateAsync(Phone phone)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<Phone>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Phone> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public List<Phone> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Phone phone)
        {
            throw new NotImplementedException();
        }
    }
}
