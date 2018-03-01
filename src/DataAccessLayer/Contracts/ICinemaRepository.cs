using System.Collections.Generic;
using System.Net;
using DataAccessLayer.Models.DataTransferObjects;
using DataAccessLayer.Models.Entities;
using JetBrains.Annotations;

namespace DataAccessLayer.Contracts
{
    public interface ICinemaRepository
    {
        [NotNull]
        IEnumerable<CinemaResponse> GetCinemas();

        [NotNull]
        CinemaResponse GetCinemaById(int id);

        [NotNull]
        int AddCinema([NotNull] CinemaRequest cinema);

        HttpStatusCode DeleteCinema(int id);
    }
}
