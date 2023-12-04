using AutoMapper;
using App.Domain.Entities;
using App.DAL.Data;
using App.Domain.Interfaces.IRepositories;

namespace App.DAL.Repositories
{
    public class DepartmentRepo : BaseRepository<Department, int>, IDepartmentRepo
    {
        public DepartmentRepo(DataContext dataContext) : base(dataContext)
        {

        }             
    }
}
