using CSB.Repository.Entities;
using CSB.Repository.GenericRepo;
using CSB.Repository.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSB.Repository.Interfaces
{
    internal interface IPhoneRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        Phone GetById(int id);
        int Create(T phone);

        bool Update(T phone);

        bool Delete(int id);

        List<Phone> GetByName(string name);
    }
}
