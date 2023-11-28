using App.DAL.Data;
using App.Domain.Entities;
using App.Domain.Interfaces.IRepositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL.Repositories
{
    public class BaseRepository<T, K> : IBaseRepository<T, K> where T : class
    {
        protected readonly DataContext _dataContext;
        protected readonly DbSet<T> _dbSet;
        protected readonly IMapper _mapper;

        public BaseRepository(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _dbSet = _dataContext.Set<T>();
            _mapper = mapper;
        }

        public async Task<K> CreateAsync(T model)
        {
            var newEntity = _mapper.Map<T>(model); 
            _dbSet.Add(newEntity);
            await _dataContext.SaveChangesAsync();

            var entityId = typeof(T).GetProperty("ID")?.GetValue(newEntity);

            if (entityId != null && entityId is K result)
            {
                return result;
            }
            throw new InvalidOperationException($"Unable to extract valid ID from created entity of type {typeof(T)}.");
        }

        public Task<K> DeleteAsync(K k)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(K k)
        {
            throw new NotImplementedException();
        }

        public Task<K> UpdateAsync(T t, K k)
        {
            throw new NotImplementedException();
        }
    }
}
