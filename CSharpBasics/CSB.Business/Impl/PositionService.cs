using CSB.Business.Exceptions;
using CSB.Business.Interfaces;
using CSB.Repository.Entities;
using CSB.Repository.Interfaces;
using System;

namespace CSB.Business.Impl
{
    internal class PositionService : IPositionService
    {
        private readonly IPositionRepository _positionRepository;
        public PositionService(IPositionRepository positionRepository)
        {
            _positionRepository = positionRepository;
        }
        public Position GetPositionByEmployeeId(int employeeId)
        {
            if (employeeId <= 0)
            {
                throw new ArgumentException("wrong Id");
            }

            var position = _positionRepository.GetPositionByEmployeeId(employeeId);
            if(position is null)
            {
                throw new NotFoundException("no position");
            }

            return position;
        }
    }
}
