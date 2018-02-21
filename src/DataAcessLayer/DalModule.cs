using AutoMapper;
using DataAcessLayer.Contracts;
using DataAcessLayer.Models.DataTransferObjects;
using DataAcessLayer.Models.Entities;
using DataAcessLayer.Repositories;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;

namespace DataAcessLayer
{
    public static class DalModule
    {
        public static void Register([NotNull] IServiceCollection collection)
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<User, UserDto>();
            });

            collection.AddSingleton<IUserRepository, UserRepository>();
        }
    }
}