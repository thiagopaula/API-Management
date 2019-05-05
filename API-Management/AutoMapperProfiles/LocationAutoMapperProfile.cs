using API_Management.ViewModel;
using AutoMapper;
using Domain.Entities;


namespace API_Management.AutoMapperProfiles
{
    public class LocationAutoMapperProfile : Profile
    {
        public LocationAutoMapperProfile()
        {
            CreateMap<Location, LocationViewModel>();
            CreateMap<LocationViewModel, Location>();
            CreateMap<LocationCreateViewModel, Location>();
        }
    }
}
