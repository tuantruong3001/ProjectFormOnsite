using App.DAL.Data;
using App.Domain.Interfaces.IRepositories;
using App.Domain.Interfaces.IServices;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace App.Application.Services
{
    public class BaseService<T, K> : IBaseService<T, K> where T : class
    {
        protected readonly DataContext _dataContext;
        protected readonly DbSet<T> _dbSet;
        protected readonly IMapper _mapper;
        protected readonly IBaseRepository<T, K> _baseRepo;

        public BaseService(DataContext dataContext, IMapper mapper, IBaseRepository<T, K> baseRepo)
        {
            _dataContext = dataContext;
            _dbSet = _dataContext.Set<T>();
            _mapper = mapper;
            _baseRepo = baseRepo;
        }

        public async Task<T> CreateAsync(T entity)
        {
            return await _baseRepo.CreateAsync(entity); ;
        }

        public async Task DeleteAsync(K id)
        {
            await _baseRepo.DeleteAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _baseRepo.GetAllAsync();
        }

        public async Task<T> GetByIdAsync(K id)
        {
            return await _baseRepo.GetByIdAsync(id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            return await _baseRepo.UpdateAsync(entity);
        }
    }
}
