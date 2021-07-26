using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSB.Repository.Entities;
using CSB.Repository.GenericRepo;
using CSB.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CSB.Repository.Impl
{
    class FamilyMemberRepository : GenericRepository<FamilyMember>, IFamilyMemberRepository
    {
        public FamilyMemberRepository(CbsDbContext dbContext) : base(dbContext)
        {
        }
        public List<FamilyMember> FamilyMembers;

        private readonly CbsDbContext dbContext;

        public async Task<IReadOnlyCollection<FamilyMember>> GetByEmployeeIdAsync(int employeeId)
        {
            return await dbContext.FamilyMembers.Where(x => x.EmployeeId == employeeId).ToListAsync();
        }
    }
}
