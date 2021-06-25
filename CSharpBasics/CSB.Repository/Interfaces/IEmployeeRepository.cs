using CSB.Repository.Entities;
using CSB.Repository.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSB.Repository.Interfaces
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Task<IReadOnlyCollection<Employee>> GetByNameAsync(string name);

        Task<IReadOnlyCollection<Employee>> GetOlderThanAsync(int age);

        Task<IReadOnlyCollection<Employee>> GetByGenderAsync(short gender);

        Task<IReadOnlyCollection<Employee>> GetByPositionAsync(string code);

        Task<IReadOnlyCollection<Position>> GetPositionByCodeAsync(string code);



    }
}
