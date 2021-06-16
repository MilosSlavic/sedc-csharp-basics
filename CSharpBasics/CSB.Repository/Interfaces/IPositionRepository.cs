using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSB.Repository.GenericRepo;
using CSB.Repository.Entities;

namespace CSB.Repository.Interfaces
{
    public interface IPositionRepository : IGenericRepository<Position>
    {
        Task<Position> GetPositionByEmployeeIdAsync(int employeeId);
    }
}
