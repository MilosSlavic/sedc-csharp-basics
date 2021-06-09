using CSB.Business.Models;
using System.Threading.Tasks;

namespace CSB.Business.Interfaces
{
    public interface IEmployeeService
    {
        GetEmployeeDto GetById(int id);

        Task<int> CreateAsync(CreateEmployeeDto employee);
    }
}
