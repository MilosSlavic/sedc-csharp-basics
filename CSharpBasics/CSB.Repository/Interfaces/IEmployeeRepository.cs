using CSB.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSB.Repository.Interfaces
{
    public interface IEmployeeRepository
    {
        Employee GetById(int id);

        int Create(Employee employee);

        bool Update(Employee employee);

        bool Delete(int id);
    }
}
