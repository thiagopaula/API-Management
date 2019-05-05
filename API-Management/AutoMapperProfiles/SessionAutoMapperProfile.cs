using API_Management.ViewModel;
using AutoMapper;
using Domain.Entities;

namespace API_Management.AutoMapperProfiles
{
    public class SessionAutoMapperProfile : Profile
    {
        public SessionAutoMapperProfile()
        {
            CreateMap<Session, SessionViewModel>();
            CreateMap<SessionViewModel, Session>();
            CreateMap<SessionCreateViewModel, Session>();
        }
    }
}
