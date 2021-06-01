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

namespace CSB.Business.Impl
{
    internal class PositionService : GenericRepository<Position>, IPositionService
    {
        private readonly CbsDbContext dbContext;


        public PositionService(CbsDbContext dbContext) : base(dbContext)
        {

        }



        public int Create(Position item)
        {
            dbContext.Set<Position>().Add(item);
            dbContext.SaveChanges();
            return item.Id;

        }
        public Position GetById(int id)
        {
            return dbContext.Set<Position>().SingleOrDefault<Position>(x => x.Id == id);
        }

        public bool Delete(int id)
        {
            var item = GetById(id);
            if (item == null)
            {
                return false;
            }
            dbContext.Set<Position>().Remove(item);
            dbContext.SaveChanges();
            return true;
        }

        public IReadOnlyCollection<Position> GetAll()
        {
            return dbContext.Set<Position>().ToList();
        }


        public bool Update(Position item)
        {
            var entry = dbContext.Entry(item);
            entry.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();
            return true;
        }
    }
}
