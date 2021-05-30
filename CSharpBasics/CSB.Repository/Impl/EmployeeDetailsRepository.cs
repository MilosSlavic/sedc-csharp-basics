using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSB.Repository.Entities;
using CSB.Repository.Interfaces;

namespace CSB.Repository.Impl
{
    internal class EmployeeDetailsRepository : IEmployeeDetailsRepository
    {   
        private FileDbProvider _fileDb;
        public EmployeeDetailsRepository(FileDbProvider fileDb)
        {
            _fileDb = fileDb;
        }

        public int AddPhone(Phone phone)
        {
            var maxId = _fileDb.Phones.Max(x => x.Id);
            phone.Id = maxId + 1;
            _fileDb.Phones.Add(phone);
            _fileDb.Save();
            return phone.Id;

        }
        public int AddPosition(Position position)
        {
            var maxId = _fileDb.Positions.Max(x => x.Id);
            position.Id = maxId + 1;
            _fileDb.Positions.Add(position);
            _fileDb.Save();
            return position.Id;
        }

        public IReadOnlyList<Phone> GetPhones(int employeeId)
        {
            return _fileDb.Phones.Where(x => x.EmployeeId == employeeId).ToList();
        }

        public Position GetPosition(int employeeId)
        {
            var existingEmployee = _fileDb.Employees.FirstOrDefault(x => x.Id == employeeId);
            if (existingEmployee != null)
            {
                return existingEmployee.Position;
            }
            return null;
        }

        public IReadOnlyList<Position> GetAllPositions()
        {
            return _fileDb.Positions;
        }
    }
}
