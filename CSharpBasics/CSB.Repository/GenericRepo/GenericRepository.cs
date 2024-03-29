using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSB.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace CSB.Repository.GenericRepo
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly CbsDbContext dbContext;

        public GenericRepository(CbsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await dbContext.Set<T>().SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> CreateAsync(T item)
        {
            dbContext.Set<T>().Add(item);
            await dbContext.SaveChangesAsync();
            return item.Id;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var item = await dbContext.Set<T>().SingleOrDefaultAsync(x => x.Id == id);
            dbContext.Set<T>().Remove(item);
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IReadOnlyCollection<T>> GetAllAsync()
        {
            return await dbContext.Set<T>().ToListAsync();
        }

        public async Task<bool> UpdateAsync(T item)
        {
            var entry = dbContext.Entry(item);
            entry.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            var rowsAffected = await dbContext.SaveChangesAsync();

            return rowsAffected == 1;
        }
    }
}
