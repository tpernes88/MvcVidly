using AutoMapper;
using VidlyMvc.Models;
using VidlyMvc.Models.Dtos;

namespace VidlyMvc.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();
        }
    }
}