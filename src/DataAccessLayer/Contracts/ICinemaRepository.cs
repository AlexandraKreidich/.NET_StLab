using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using DataAccessLayer.Models.DataTransferObjects;
using DataAccessLayer.Models.Entities;
using JetBrains.Annotations;

namespace DataAccessLayer.Contracts
{
    public interface ICinemaRepository
    {
        [ItemNotNull]
        Task<IEnumerable<CinemaResponse>> GetCinemas();

        [ItemCanBeNull]
        Task<CinemaResponse> GetCinemaById(int id);

        Task<int> AddCinema([NotNull] CinemaRequest cinema);

        Task<HttpStatusCode> DeleteCinema(int id);
    }
}
