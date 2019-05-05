using API_Management.ViewModel;
using AutoMapper;
using Domain.Entities;

namespace API_Management.AutoMapperProfiles
{
    public class TheaterAutoMapperProfile : Profile
    {
        public TheaterAutoMapperProfile()
        {
            CreateMap<Theater, TheaterViewModel>();
            CreateMap<TheaterViewModel, Theater>();
            CreateMap<TheaterCreateViewModel, Theater>();
        }
    }
}
