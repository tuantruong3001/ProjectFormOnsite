﻿using AutoMapper;
using App.API.Models;
using App.Domain.Entities;

namespace App.API.Helpers
{
    public class EmployeeMapper : Profile
    {
        public EmployeeMapper()
        {
            CreateMap<Employee, EmployeeModel>().ReverseMap();
            CreateMap<Employee, AddEmployeeModel>().ReverseMap();
        }
    }
}
