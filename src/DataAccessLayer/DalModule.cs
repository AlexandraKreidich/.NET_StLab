using AutoMapper;
using DataAccessLayer.Contracts;
using DataAccessLayer.Models.DataTransferObjects;
using DataAccessLayer.Models.Entities;
using DataAccessLayer.Repositories;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccessLayer
{
    public static class DalModule
    {
        public static void Register([NotNull] IServiceCollection collection)
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<User, UserResponse>();
            });

            Mapper.Initialize(cfg => {
                    cfg.CreateMap<Cinema, CinemaResponse>();
                });

            collection.AddSingleton<IUserRepository, UserRepository>();
            collection.AddSingleton<ICinemaRepository, CinemaRepository>();
        }
    }
}