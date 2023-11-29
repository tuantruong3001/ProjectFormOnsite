using App.Domain.Interfaces.IServices;

namespace App.Application.Services
{
    public class BaseService<T, K> : IBaseService<T, K> where T : class
    {
       
        public Task<IEnumerable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(K id)
        {
            throw new NotImplementedException();
        }
    }
}
