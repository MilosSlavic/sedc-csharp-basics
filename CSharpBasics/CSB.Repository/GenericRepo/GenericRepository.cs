using CSB.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSB.Repository.GenericRepo
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly CbsDbContext dbContext;

        public GenericRepository(CbsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public T GetById(int id)
        {
            return dbContext.Set<T>().SingleOrDefault<T>(x => x.Id == id);
        }

        public async Task<int> CreateAsync(T item)
        {
            dbContext.Set<T>().Add(item);
            await dbContext.SaveChangesAsync();
            return item.Id;
        }

        public bool Delete(int id)
        {
            var item = GetById(id);
            if (item == null)
            {
                return false;
            }

            dbContext.Set<T>().Remove(item);
            dbContext.SaveChanges();
            return true;
        }

        public async Task<IReadOnlyCollection<T>> GetAllAsync()
        {
            return await dbContext.Set<T>().ToListAsync();
        }

        public bool Update(T item)
        {
            var entry = dbContext.Entry(item);
            entry.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();
            return true;
        }
    }
}
