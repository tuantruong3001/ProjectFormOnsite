using App.Domain.Entities;
using App.Domain.Models;
using AutoMapper;

namespace App.API.Helpers.AutoMapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Department, DepartmentModel>().ReverseMap();
            CreateMap<Employee, EmployeeModel>().ReverseMap();
            CreateMap<Employee, AddEmployeeModel>().ReverseMap();
            CreateMap<Onsite, OnsiteModel>().ReverseMap();
            CreateMap<Onsite, InforOnsiteModel>().ReverseMap();
            CreateMap<Department, InforOnsiteModel>().ReverseMap();
            CreateMap<Onsite, ConfirmModel>().ReverseMap();
            CreateMap<Onsite, RegisterOnsiteModel>().ReverseMap();
        }

    }
}
