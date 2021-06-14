using System.Collections.Generic;
using CSB.Repository.Entities;
using CSB.Repository.GenericRepo;

namespace CSB.Repository.Interfaces
{
    public interface IPhoneRepository : IGenericRepository<Phone>
    {
        List<Phone> GetByName(string name);
    }
}
