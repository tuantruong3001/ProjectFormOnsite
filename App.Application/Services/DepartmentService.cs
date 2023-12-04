using App.DAL.Data;
using App.Domain.Entities;
using App.Domain.Interfaces.IRepositories;
using App.Domain.Interfaces.IServices;
using AutoMapper;

namespace App.Application.Services
{
    public class DepartmentService : BaseService<Department, int>, IDepartmentService
    {
        private readonly IDepartmentRepo _departmentRepo;
        public DepartmentService(DataContext dataContext, IMapper mapper, IDepartmentRepo departmentRepo) : base(dataContext, mapper, departmentRepo)
        {
            _departmentRepo = departmentRepo;
        }
    }
}
