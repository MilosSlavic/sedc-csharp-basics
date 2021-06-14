using CSB.Repository.Entities;
using CSB.Repository.GenericRepo;
using System.Collections.Generic;
namespace CSB.Business.Interfaces
{
    public interface IPositionService
    {
        int Create(Position item);

        bool Update(Position item);

        bool Delete(int id);

        Position GetById(int id);

        IReadOnlyCollection<Position> GetAll();
    }
}
