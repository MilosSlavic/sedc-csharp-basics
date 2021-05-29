using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSB.Repository.GenericRepo;
using CSB.Repository.Entities;
using CSB.Repository.Interfaces;

namespace CSB.Repository.Impl
{
    public class PositionRepository : GenericRepository<Position>, IPositionRepository
    {
        private readonly CbsDbContext dbContext;

        public PositionRepository(CbsDbContext dbContext) : base(dbContext)
        {
            
        }

        public Position GetPosition(int id)
        {
            var item = dbContext.Set<Employee>().SingleOrDefault<Employee>(x => x.Id == id);
            if(item != null)
            {
                return item.Position;
            }
            return null;
        }
    }
}
