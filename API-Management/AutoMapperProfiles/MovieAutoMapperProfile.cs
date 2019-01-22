using API_Management.ViewModel;
using AutoMapper;
using Domain.Entities;

namespace API_Management.AutoMapperProfiles
{
    public class MovieAutoMapperProfile : Profile
    {
        public MovieAutoMapperProfile()
        {
            CreateMap<Movie, MovieViewModel>();
            CreateMap<MovieViewModel, Movie>();
            CreateMap<MovieCreateViewModel, Movie>();
        }
    }
}
