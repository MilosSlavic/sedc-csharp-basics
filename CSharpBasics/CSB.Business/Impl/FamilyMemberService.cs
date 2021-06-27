using CSB.Business.Exceptions;
using CSB.Business.Interfaces;
using CSB.Repository.Entities;
using CSB.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSB.Business.Impl
{
    class FamilyMemberService : IFamilyMemberService
    {
        private readonly IFamilyMemberRepository _familyMemberRepository;

        public FamilyMemberService(IFamilyMemberRepository familyMemberRepository)
        {
            this._familyMemberRepository = familyMemberRepository;
        }

        public Task<int> CreateAsync(FamilyMember item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<FamilyMember>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<FamilyMember> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(FamilyMember item)
        {
            throw new NotImplementedException();
        }
    }
}
