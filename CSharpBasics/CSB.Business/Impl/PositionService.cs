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
        public Task<int> CreateAsync(Position item)
        {
            if(item == null)
            {
                throw new ArgumentNullException();
            }
            return _positionRepository.CreateAsync(item);

        }
        public Task<Position> GetByIdAsync(int id)
        {
            if(id <= 0)
            {
                throw new ArgumentException();
            }
            return _positionRepository.GetByIdAsync(id);
        }

        public Task<bool> DeleteAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException();
            }
            return _positionRepository.DeleteAsync(id);
        }

        public Task<IReadOnlyCollection<Position>> GetAllAsync()
        {
            return _positionRepository.GetAllAsync();
        }


        public Task<bool> UpdateAsync(Position item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }
            return _positionRepository.UpdateAsync(item);
        }

        public Position GetPositionByEmployeeId(int employeeId)
        {
            if (employeeId <= 0)
            {
                throw new ArgumentException();
            }
            return _positionRepository.GetPositionByEmployeeId(employeeId);
        }

    }
}
