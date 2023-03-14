using AutoMapper;
using BlazorFullStackCrud.Shared.DTO;
using Core.Entities;

namespace BlazorFullStackCrud.Server.Common
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<Order, OrderDTO>()
                .ForMember(dest => dest.Windows, opt => opt.MapFrom(src => src.Windows));
            CreateMap<Window, WindowDTO>()
                .ForMember(dest => dest.SubElements, opt => opt.MapFrom(src => src.SubElements));
            CreateMap<SubElement, SubElementDTO>();
        }
    }

}
