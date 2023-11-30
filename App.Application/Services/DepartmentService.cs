using App.DAL.Data;
using App.Domain.Entities;
using App.Domain.Interfaces.IServices;
using AutoMapper;

namespace App.Application.Services
{
    public class DepartmentService : BaseService<Department, int>, IDepartmentService
    {
        public DepartmentService(DataContext dataContext, IMapper mapper) : base(dataContext, mapper)
        {

        }
    }
}
