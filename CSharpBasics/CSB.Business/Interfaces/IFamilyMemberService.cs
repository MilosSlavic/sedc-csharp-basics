using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSB.Repository.Entities;

namespace CSB.Business.Interfaces
{
    public interface IFamilyMemberService
    {
        Task<int> CreateAsync(FamilyMember item);

        Task<bool> UpdateAsync(FamilyMember item);

        Task<bool> DeleteAsync(int id);

        Task<FamilyMember> GetByIdAsync(int id);

        Task<IReadOnlyCollection<FamilyMember>> GetAllAsync();
    }
}
