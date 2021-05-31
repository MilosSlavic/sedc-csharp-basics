using CSB.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSB.Repository.GenericRepo
{
    public interface IPhoneRepository<T> where T : BaseEntity
    {
        //treba metode: create, update, delete, getAll, getById
        int Create(T item);

        bool Update(T item);

        bool Delete(int id);

        T GetById(int id);

        IReadOnlyCollection<T> GetAll();
    }
}
