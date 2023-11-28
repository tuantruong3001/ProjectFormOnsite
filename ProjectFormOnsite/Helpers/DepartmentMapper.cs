using AutoMapper;
using App.Domain.Models;
using App.Domain.Entities;

namespace App.API.Helpers
{
    public class DepartmentMapper : Profile
    {
        public DepartmentMapper()
        {
            CreateMap<Department, DepartmentModel>().ReverseMap();
        }
    }
}
