using System.Collections.Generic;
using CSB.Repository.Entities;

namespace CSB.Business.Interfaces
{
    public interface IPhoneService
    {
        int Create(Phone phone);

        bool Update(Phone phone);

        bool Delete(int id);

        Phone GetById(int id);

        IReadOnlyCollection<Phone> GetAll();
    }
}
