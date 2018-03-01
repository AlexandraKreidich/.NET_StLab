using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BusinessLayer.Models;
using DataAccessLayer.Models.DataTransferObjects;
using JetBrains.Annotations;

namespace BusinessLayer
{
    public static class BlMappings
    {
        public static void Initialize([NotNull] IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<CinemaModelResponse, CinemaResponse>();
        }
    }
}
