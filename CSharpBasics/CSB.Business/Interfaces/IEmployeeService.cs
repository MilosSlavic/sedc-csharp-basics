using CSB.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSB.Business.Interfaces
{
    public interface IEmployeeService
    {
        GetEmployeeDto GetById(int id);

        Task<IReadOnlyCollection<GetEmployeeDto>> GetAllAsync();

        Task<int> CreateAsync(CreateEmployeeDto employee);
    }
}
