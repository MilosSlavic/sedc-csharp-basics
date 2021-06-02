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
        private readonly CbsDbContext dbContext;
        public PhoneRepository(CbsDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
        
    }
}
