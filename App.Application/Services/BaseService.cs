using App.DAL.Data;
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

        public BaseService(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _dbSet = _dataContext.Set<T>();
            _mapper = mapper;
        }

    }
}
