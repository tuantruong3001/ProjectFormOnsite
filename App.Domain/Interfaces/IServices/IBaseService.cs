using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Interfaces.IServices
{
    public interface IBaseService<T, K>
    {
        public Task<T> GetByIdAsync(K id);
        public Task<IEnumerable<T>> GetAllAsync();
    }
}
