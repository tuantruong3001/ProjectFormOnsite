using AutoMapper;
using ProjectFormOnsite.Data;
using ProjectFormOnsite.Models;

namespace ProjectFormOnsite.Helpers
{
    public class EmployeeMapper : Profile
    {
        public EmployeeMapper()
        {
            CreateMap<Employee, EmployeeModel>().ReverseMap();
        }
    }
}
