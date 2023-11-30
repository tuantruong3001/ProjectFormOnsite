using AutoMapper;
using App.Domain.Entities;
using App.DAL.Data;
using App.Domain.Interfaces.IRepositories;

namespace App.DAL.Repositories
{
    public class EmployeeRepo : BaseRepository<Employee, int>, IEmployeeRepo
    {
        public EmployeeRepo(DataContext dataContext, IMapper mapper) : base(dataContext, mapper)
        {

        }  
       
    }
}
