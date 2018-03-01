﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Contracts;
using BusinessLayer.Models;
using DataAccessLayer.Contracts;
using DataAccessLayer.Models.DataTransferObjects;
using JetBrains.Annotations;

namespace BusinessLayer.Services
{
    public class CinemasService : ICinemasService
    {
        [NotNull]
        private readonly ICinemaRepository _cinemaRepository;

        public CinemasService([NotNull] ICinemaRepository cinemaRepository)
        {
            _cinemaRepository = cinemaRepository;
        }

        public async Task<IEnumerable<CinemaModelResponse>> GetCinemas()
        {
            IEnumerable<CinemaResponse> cinemas = await _cinemaRepository.GetCinemas();

            return cinemas.Select(Mapper.Map<CinemaModelResponse>);
        }

        public async Task<CinemaModelResponse> GetCinemaById(int id)
        {
            CinemaResponse cinema = await _cinemaRepository.GetCinemaById(id);

            return (cinema == null) ? null : Mapper.Map<CinemaModelResponse>(cinema);
        }

        public async Task<CinemaModelResponse> AddCinema(CinemaModelRequest cinema)
        {
            CinemaRequest cinemaToAdd = new CinemaRequest(cinema.Name, cinema.City);

            int newCinemaId = await _cinemaRepository.AddCinema(cinemaToAdd);

            return new CinemaModelResponse
            (
                newCinemaId,
                cinema.Name,
                cinema.City,
                0
            );
        }

        public async Task<HttpStatusCode> DeleteCinema(int id)
        {
            return await _cinemaRepository.DeleteCinema(id);
        }
    }
}
