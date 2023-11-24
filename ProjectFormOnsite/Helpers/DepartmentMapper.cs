using AutoMapper;
using ProjectFormOnsite.Data;
using ProjectFormOnsite.Models;

namespace ProjectFormOnsite.Helpers
{
    public class DepartmentMapper : Profile
    {
        public DepartmentMapper() {
            CreateMap<Department, DepartmentModel>().ReverseMap();
        }
    }
}
