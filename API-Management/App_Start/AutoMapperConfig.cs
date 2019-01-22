using API_Management.AutoMapperProfiles;
using AutoMapper;


namespace API_Management.App_Start
{
    public class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfiles(new[]
                {
                    typeof(CityAutoMapperProfile),
                    typeof(TheaterAutoMapperProfile),
                    typeof(LocationAutoMapperProfile),
                    typeof(MovieAutoMapperProfile),
                    typeof(SessionAutoMapperProfile)
                });
            });
        }
    }
}
