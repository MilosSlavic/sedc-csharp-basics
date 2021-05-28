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
    //public abstract class PhoneRepository<T> : GenericRepository<T> where T : BaseEntity
    public class PhoneRepository<T> : IPhoneRepository<T>  where T : BaseEntity
    {
        private readonly CbsDbContext dbContext;

        public PhoneRepository(CbsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        //public PhoneRepository(CbsDbContext dbContext) : GenericRepository(dbContext);

        private FileDbProvider _fileDb;
        public PhoneRepository(FileDbProvider fileDb)
        {
            _fileDb = fileDb;
        }

        public Phone GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Create(Phone phone)
        {
            var maxId = _fileDb.Phones.Max(x => x.Id);
            phone.Id = maxId + 1;
            _fileDb.Phones.Add(phone);
            _fileDb.Save();
            return phone.Id;
        }

        public bool Update(Phone phone)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Phone> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public int Create(T item)
        {
            throw new NotImplementedException();
        }

        public bool Update(T item)
        {
            throw new NotImplementedException();
        }

        T IGenericRepository<T>.GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<T> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
