using AutoMapper;
using BusinessLayer.Contracts;
using BusinessLayer.Models;
using BusinessLayer.Services;
using DataAccessLayer.Models.DataTransferObjects;
using DataAccessLayer.Models.Entities;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLayer
{
    public static class BlModule
    {
        public static void Register([NotNull] IServiceCollection collection)
        {
            collection.AddSingleton<IUserService, UserService>();
            collection.AddSingleton<ICinemasService, CinemasService>();
        }
    }
}