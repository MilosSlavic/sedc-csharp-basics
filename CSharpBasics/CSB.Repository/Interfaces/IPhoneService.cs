using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSB.Repository.Entities;
using CSB.Repository.GenericRepo;

namespace CSB.Repository.Interfaces
{
    public interface IPhoneService<T> where T : Phone
    {
        List<Phone> GetByName(string name);

        int Create(string name);

        bool Update(string name);

        bool Delete(string name);

        T GetById(int id);

        IReadOnlyCollection<T> GetAll();
    }
}
