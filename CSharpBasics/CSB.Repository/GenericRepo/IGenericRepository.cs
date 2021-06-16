using CSB.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSB.Repository.GenericRepo
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        //treba metode: create, update, delete, getAll, getById
        Task<int> CreateAsync(T item);

        Task<bool> UpdateAsync(T item);

        Task<bool> DeleteAsync(int id);

        Task<T> GetByIdAsync(int id);

        Task<IReadOnlyCollection<T>> GetAllAsync();
    }
}
