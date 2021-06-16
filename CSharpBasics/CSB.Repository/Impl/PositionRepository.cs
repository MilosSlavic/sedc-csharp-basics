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

        public List<Position> Positions;
        public PositionRepository(CbsDbContext dbContext) : base(dbContext)
        { 

        }

        public Task<Position> GetPositionByEmployeeIdAsync(int employeeId)
        {
            throw new NotImplementedException();
        }
    }
}
