using AutoMapper;
using VendorApi.Domain.Entities;
using VendorApi.Infrastructure.Dto;

namespace VendorApi.Infrastructure.Mapping
{
    public class VendorProfile : Profile
    {
        public VendorProfile()
        {
            CreateMap<VendorDto, Vendor>().ReverseMap();
        }
    }
}
