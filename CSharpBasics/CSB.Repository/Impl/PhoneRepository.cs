using System;
using CSB.Repository.Entities;
using CSB.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSB.Repository.GenericRepo;

namespace CSB.Repository.Impl
{
    public class PhoneRepository : IPhoneRepository
    {
        public int Create(Phone item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<Phone> GetAll()
        {
            throw new NotImplementedException();
        }

        public Phone GetById(int id)
        {
            throw new NotImplementedException();
        }
        public List<Phone> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool Update(Phone item)
        {
            throw new NotImplementedException();
        }
    }
}
