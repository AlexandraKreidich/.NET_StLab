using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Models;
using JetBrains.Annotations;

namespace BusinessLayer.Contracts
{
    public interface ICinemasService
    {
        [ItemNotNull]
        Task<IEnumerable<CinemaModelResponse>> GetCinemas();

        [ItemCanBeNull]
        Task<CinemaModelResponse> GetCinemaById(int id);

        [NotNull]
        Task<CinemaModelResponse> AddCinema([NotNull] CinemaModelRequest cinema);

        Task<HttpStatusCode> DeleteCinema(int id);
    }
}
