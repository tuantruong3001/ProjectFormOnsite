using App.DAL.Data;
using App.Domain.Entities;
using App.Domain.Interfaces.IRepositories;
using App.Domain.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
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

        public async Task<T> CreateAsync(T model)
        {
            var result = _mapper.Map<T>(model);
            _dbSet.Add(result);
            await _dataContext.SaveChangesAsync();
            return result;
        }

        public async Task DeleteAsync(K id)
        {
            var existingEntity = await _dbSet.FindAsync(id);
            if (existingEntity != null)
            {
                _dbSet.Remove(existingEntity);
                await _dataContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var result = await _dbSet.ToListAsync();
            return result;
        }

        public async Task<T> GetByIdAsync(K id)
        {
            var result = await _dbSet.FindAsync(id);
            return result!;
        }

        public async Task<T> UpdateAsync(T model, K id)
        {
            var entry = _dbSet.Update(model);
            await _dataContext.SaveChangesAsync();
            return entry.Entity;
        }
    }
}
