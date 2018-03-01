using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using BusinessLayer.Models;
using JetBrains.Annotations;

namespace BusinessLayer.Contracts
{
    public interface ICinemasService
    {
        [NotNull]
        IEnumerable<CinemaModelResponse> GetCinemas();

        [NotNull]
        CinemaModelResponse GetCinemaById(int id);

        [NotNull]
        CinemaModelResponse AddCinema([NotNull] CinemaModelRequest cinema);

        HttpStatusCode DeleteCinema(int id);
    }
}
