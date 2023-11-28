using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Interfaces.IRepositories
{
    public interface IBaseRepository<T, K>
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> GetByIdAsync(K k);
        public Task<K> CreateAsync(T t);
        public Task<K> UpdateAsync(T t, K k);
        public Task<K> DeleteAsync(K k);
    }
}
