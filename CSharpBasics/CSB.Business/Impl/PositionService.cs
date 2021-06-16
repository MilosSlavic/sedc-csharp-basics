using CSB.Business.Exceptions;
using CSB.Business.Interfaces;
using CSB.Repository;
using CSB.Repository.Entities;
using CSB.Repository.GenericRepo;
using CSB.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSB.Business.Impl
{
    internal class PositionService : IPositionService
    {
        private readonly IPositionRepository _positionRepository;

        public PositionService(IPositionRepository positionRepository)
        {
            this._positionRepository = positionRepository;
        }
        public int Create(Position item)
        {
            if(item == null)
            {
                throw new ArgumentNullException();
            }
            return _positionRepository.Create(item);

        }
        public Position GetById(int id)
        {
            if(id <= 0)
            {
                throw new ArgumentException();
            }
            return _positionRepository.GetById(id);
        }

        public bool Delete(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException();
            }
            return _positionRepository.Delete(id);
        }

        public IReadOnlyCollection<Position> GetAll()
        {
            return _positionRepository.GetAll();
        }


        public bool Update(Position item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }
            return _positionRepository.Update(item);
        }

        public async Task<Position> GetPositionByEmployeeIdAsync(int employeeId)
        {
            if (employeeId <= 0)
            {
                throw new ArgumentException();
            }
            return await _positionRepository.GetPositionByEmployeeIdAsync(employeeId);
        }

    }
}
