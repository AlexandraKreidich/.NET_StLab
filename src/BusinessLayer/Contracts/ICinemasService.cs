using System.Collections.Generic;
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

        [ItemNotNull]
        Task<CinemaModelResponse> AddCinema([NotNull] CinemaModelRequest cinema);

        [ItemNotNull]
        Task<IEnumerable<HallModelResponse>> GetHalls(int hallId);
    }
}
