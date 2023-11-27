using AutoMapper;
using ProjectFormOnsite.Data;
using ProjectFormOnsite.Models;

namespace ProjectFormOnsite.Helpers
{
    public class OnsiteMapper : Profile
    {
        public OnsiteMapper()
        {
            CreateMap<Onsite, OnsiteModel>().ReverseMap();
            CreateMap<Onsite, InforOnsiteModel>().ReverseMap();
            CreateMap<Department, InforOnsiteModel>().ReverseMap();
            CreateMap<Onsite, ConfirmModel>().ReverseMap();
        }
    }
}
