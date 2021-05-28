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
    public class PhoneRepository : GenericRepository
    {
        private readonly CbsDbContext dbContext;

        public PhoneRepository(CbsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        private FileDbProvider _fileDb;

        public PhoneRepository(FileDbProvider fileDb)
        {
            _fileDb = fileDb;
        }

        //public int Create(Phone phone)
        //{
        //    var maxId = _fileDb.Phones.Max(x => x.Id);
        //    phone.Id = maxId + 1;
        //    _fileDb.Phones.Add(phone);
        //    _fileDb.Save();
        //}
        public List<Phone> GetByName(string name)
        {
            return (List<Phone>)_fileDb.Employees.Where(x => x.FirstName == name);
        }
    }

    public class GenericRepository
    {
    }
}
