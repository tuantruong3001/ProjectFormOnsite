using AutoMapper;
using App.Domain.Models;
using App.Domain.Entities;

namespace App.API.Helpers
{
    public class OnsiteMapper : Profile
    {
        public OnsiteMapper()
        {
            CreateMap<Onsite, OnsiteModel>().ReverseMap();
            CreateMap<Onsite, InforOnsiteModel>().ReverseMap();
            CreateMap<Department, InforOnsiteModel>().ReverseMap();
            CreateMap<Onsite, ConfirmModel>().ReverseMap();
            CreateMap<Onsite, RegisterOnsiteModel>().ReverseMap();
        }
    }
}
