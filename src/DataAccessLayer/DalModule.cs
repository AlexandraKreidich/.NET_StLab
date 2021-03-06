﻿using DataAccessLayer.Contracts;
using DataAccessLayer.Repositories;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccessLayer
{
    public static class DalModule
    {
        public static void Register([NotNull] IServiceCollection collection)
        {
            collection.AddSingleton<IUserRepository, UserRepository>();
            collection.AddSingleton<ICinemaRepository, CinemaRepository>();
            collection.AddSingleton<IServiceRepository, ServiceRepository>();
            collection.AddSingleton<IFilmRepository, FilmRepository>();
            collection.AddSingleton<IHallsRepository, HallsRepository>();
            collection.AddSingleton<ISessionsRepository, SessionsRepository>();
            collection.AddSingleton<ITicketsRepository, TicketsRepository>();
        }
    }
}