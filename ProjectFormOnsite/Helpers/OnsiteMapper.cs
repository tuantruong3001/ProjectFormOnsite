using AutoMapper;
using ProjectFormOnsite.Data;
using ProjectFormOnsite.Models;

namespace ProjectFormOnsite.Helpers
{
    public class OnsiteMapper: Profile
    {
        public OnsiteMapper()
        {
            CreateMap<Onsite, OnsiteModel>().ReverseMap();
            CreateMap<Onsite, InforOnsiteModel>().ReverseMap();
            /*CreateMap<Onsite, OnsiteModel>()
            .ForMember(d => d.FullName, a => a.MapFrom(s => s.Employee.FullName))
            .ReverseMap()
            .ForPath(b => b.Employee, o => o.MapFrom(dto => (Employee)null));*/
        }
    }
}
