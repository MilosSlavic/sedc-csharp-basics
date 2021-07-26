using CSB.Repository.Entities;
using CSB.Repository.GenericRepo;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSB.Repository.Interfaces
{
    public interface IFamilyMemberRepository : IGenericRepository<FamilyMember>
    {
        Task<IReadOnlyCollection<FamilyMember>> GetByEmployeeIdAsync(int employeeId);
    }
}
