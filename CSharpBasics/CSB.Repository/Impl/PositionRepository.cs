using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSB.Repository.GenericRepo;
using CSB.Repository.Entities;
using CSB.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CSB.Repository.Impl
{
    public class PositionRepository : GenericRepository<Position>, IPositionRepository
    {
        private readonly CbsDbContext _dbContext;

        public PositionRepository(CbsDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<Position> GetPositionByEmployeeIdAsync(int employeeId)
        {
            return await _dbContext.Positions.SingleOrDefaultAsync(x => x.Id == employeeId);
        }
    }
}
