
using API_Management.AppConfig;
using Application.Interfaces;
using Application.Services;
using Domain.Interfaces.Repositories;
using Service.Interfaces;
using LightInject;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Repositories;
using Newtonsoft.Json;
using System;
using Service.Services;
using Swashbuckle.AspNetCore.Swagger;
using API_Management.App_Start;
using LightInject.Microsoft.DependencyInjection;
using Service.Interfaces.Services;

namespace API_Management
{
    public class Startup
    {
         public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }      

       
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var container = new ServiceContainer();
            container.EnableAnnotatedPropertyInjection();

            var clientCatalogo = new MongoClient(Configuration.GetSection("MongoConnection:ConnectionString").Value);
            var databaseCatalogo = clientCatalogo.GetDatabase(Configuration.GetSection("MongoConnection:Database").Value);
            container.RegisterInstance(databaseCatalogo);


            //Injeção de dependência para repositórios
            container.Register(typeof(IRepository<>), typeof(AbstractRepository<>));
            container.Register<ICityRepository, CityRepository>(new PerRequestLifeTime());
            container.Register<ITheaterRepository, TheaterRepository>(new PerRequestLifeTime());
            container.Register<ILocationRepository, LocationRepository>(new PerRequestLifeTime());
            container.Register<IMovieRepository, MovieRepository>(new PerRequestLifeTime());
            container.Register<ISessionRepository, SessionRepository>(new PerRequestLifeTime());


            //Injeção de dependência para serviços     
            container.Register<ICityService, CityService>(new PerRequestLifeTime());
            container.Register<ITheaterService, TheaterService>(new PerRequestLifeTime());
            container.Register<ILocationService, LocationService>(new PerRequestLifeTime());
            container.Register<IMovieService, MovieService>(new PerRequestLifeTime());
            container.Register<ISessionService, SessionService>(new PerRequestLifeTime());


            //Injeção de dependência para aplicação      
            container.Register<ICityAppService, CityAppService>(new PerRequestLifeTime());
            container.Register<ITheaterAppService, TheaterAppService>(new PerRequestLifeTime());
            container.Register<ILocationAppService, LocationAppService>(new PerRequestLifeTime());
            container.Register<IMovieAppService, MovieAppService>(new PerRequestLifeTime());
            container.Register<ISessionAppService, SessionAppService>(new PerRequestLifeTime());

            services.AddSingleton<IConfiguration>(Configuration);

            services.AddMvc(options =>
            {
                options.Filters.Add(new GlobalExceptionFilter());
            }).AddJsonOptions(options =>
            {
                options.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
                options.SerializerSettings.StringEscapeHandling = StringEscapeHandling.EscapeNonAscii;
                options.SerializerSettings.NullValueHandling = NullValueHandling.Include;
            }).AddControllersAsServices();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Management System API", Version = "v1" });
            });

            return container.CreateServiceProvider(services);
        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            app.UseCors(builder =>
            {
                builder.AllowAnyOrigin();
                builder.AllowAnyMethod();
                builder.AllowAnyHeader();
                builder.AllowCredentials();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseMvc();

            AutoMapperConfig.Configure();
        }
    }
}
