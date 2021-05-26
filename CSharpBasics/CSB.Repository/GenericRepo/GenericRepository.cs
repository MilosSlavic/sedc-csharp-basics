using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSB.Repository.GenericRepo
{
    public class GenericRepository : IGenericRepository
    {
        private readonly CbsDbContext dbContext;

        public GenericRepository(CbsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
