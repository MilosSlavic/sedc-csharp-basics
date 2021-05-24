using CSB.Repository.Entities;

namespace CSB.Business.Interfaces
{
    public interface IEmployeeService
    {
        Employee GetById(int id);
    }
}
