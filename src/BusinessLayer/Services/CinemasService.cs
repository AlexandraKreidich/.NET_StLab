using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        public IEnumerable<CinemaModelResponse> GetCinemas()
        {
            IEnumerable<CinemaResponse> cinemas = _cinemaRepository.GetCinemas();

            return cinemas.Select(Mapper.Map<CinemaModelResponse>);
        }

        public CinemaModelResponse GetCinemaById(int id)
        {
            CinemaResponse cinema = _cinemaRepository.GetCinemaById(id);

            return Mapper.Map<CinemaModelResponse>(cinema);
        }

        public CinemaModelResponse AddCinema(CinemaModelRequest cinema)
        {
            CinemaRequest cinemaToAdd = new CinemaRequest(cinema.Name, cinema.City);

            int newCinemaId = _cinemaRepository.AddCinema(cinemaToAdd);

            return new CinemaModelResponse
            (
                newCinemaId,
                cinema.Name,
                cinema.City,
                0
            );
        }

        public HttpStatusCode DeleteCinema(int id)
        {
            if (_cinemaRepository.DeleteCinema(id) == HttpStatusCode.Accepted)
            {
                return HttpStatusCode.Accepted;
            }

            return HttpStatusCode.BadRequest;
        }
    }
}
