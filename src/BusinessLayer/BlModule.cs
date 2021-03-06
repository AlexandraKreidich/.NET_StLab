﻿using BusinessLayer.Contracts;
using BusinessLayer.Services;
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
            collection.AddSingleton<IServiceService, ServiceService>();
            collection.AddSingleton<IFilmsService, FilmsService>();
            collection.AddSingleton<IHallsService, HallsService>();
            collection.AddSingleton<ISessionsService, SessionsService>();
            collection.AddSingleton<ITicketsService, TicketsService>();
        }
    }
}