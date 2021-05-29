using System;
using CSB.Repository.Entities;
using CSB.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using CSB.Repository.GenericRepo;

namespace CSB.Repository.Impl
{
    public class PhoneRepository : GenericRepository<Phone>, IPhoneRepository
    {
        public PhoneRepository(CbsDbContext dbContext) : base(dbContext)
        {
        }

        public List<Phone> GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
