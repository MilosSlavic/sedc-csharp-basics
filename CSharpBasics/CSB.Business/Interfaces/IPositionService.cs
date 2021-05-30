using CSB.Repository.Entities;

namespace CSB.Business.Interfaces
{
    public interface IPositionService
    {
        Position GetPositionByEmployeeId(int employeeId);
    }
}
