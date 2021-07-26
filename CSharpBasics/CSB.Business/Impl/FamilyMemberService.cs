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

        public async Task<int> CreateAsync(FamilyMember item)
        {
            if (item is null)
            {
                throw new ArgumentException();
            }
            return await _familyMemberRepository.CreateAsync(item);
        }

        public Task<bool> DeleteAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException();
            }
            return _familyMemberRepository.DeleteAsync(id);
        }

        public Task<IReadOnlyCollection<FamilyMember>> GetAllAsync()
        {
            return _familyMemberRepository.GetAllAsync();
        }

        public Task<FamilyMember> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException();
            }
            return _familyMemberRepository.GetByIdAsync(id);
        }

        public Task<bool> UpdateAsync(FamilyMember item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }
            return _familyMemberRepository.UpdateAsync(item);
        }
    }
}
