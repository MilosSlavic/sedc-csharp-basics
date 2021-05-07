using CSB.Repository.Entities;
using CSB.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSB.Repository.Impl
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private FileDbProvider _fileDb;

        public EmployeeRepository (FileDbProvider fileDb)
        {
            _fileDb = fileDb;
        }

        public int Create(Employee employee)
        {
            int newId = _fileDb.Employees.Max(x => x.Id);

            employee.Id = newId + 1;

            _fileDb.Employees.Add(employee);

            _fileDb.Save();

            return employee.Id;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Employee GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
