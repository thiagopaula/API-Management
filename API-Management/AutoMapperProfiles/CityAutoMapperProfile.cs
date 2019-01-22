using API_Management.ViewModel;
using AutoMapper;
using Domain.Entities;


namespace API_Management.AutoMapperProfiles
{
    public class CityAutoMapperProfile : Profile
    {
        public CityAutoMapperProfile()
        {
            CreateMap<City, CityViewModel>();
            CreateMap<CityViewModel, City>();
            CreateMap<CityCreateViewModel, City>();
        }
    }
}
