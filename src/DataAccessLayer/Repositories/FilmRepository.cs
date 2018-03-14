using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dapper;
using DataAccessLayer.Contracts;
using DataAccessLayer.Models.DataTransferObjects;
using DataAccessLayer.Models.Entities;
using JetBrains.Annotations;

namespace DataAccessLayer.Repositories
{
    [UsedImplicitly]
    internal class FilmRepository : IFilmRepository
    {
        [NotNull]
        private readonly IDalSettings _settings;

        public FilmRepository([NotNull] IDalSettings settings)
        {
            _settings = settings;
        }

        public async Task<IEnumerable<FilmModel>> GetNowPlayingFilms()
        {
            using (SqlConnection connection = new SqlConnection(_settings.ConnectionString))
            {
                IEnumerable<Film> films = await connection.QueryAsync<Film>(
                    "GetNowPlayingFilms",
                    commandType: CommandType.StoredProcedure);

                //IEnumerable<FilmModel> filmModels = films.Select(Mapper.Map<FilmModel>);

                IEnumerable<FilmModel> filmModels = Mapper.Map<IEnumerable<FilmModel>>(films);

                return filmModels;
            }
        }

        public async Task<IEnumerable<FilmModel>> GetFilms()
        {
            using (SqlConnection connection = new SqlConnection(_settings.ConnectionString))
            {
                IEnumerable<Film> films = await connection.QueryAsync<Film>(
                    "GetFilms",
                    commandType: CommandType.StoredProcedure);

                //IEnumerable<FilmModel> filmModels = films.Select(Mapper.Map<FilmModel>);

                IEnumerable<FilmModel> filmModels = Mapper.Map<IEnumerable<FilmModel>>(films);

                return filmModels;
            }
        }

        public async Task<FilmModel> GetFilmById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_settings.ConnectionString))
            {
                Film film = await connection.QuerySingleOrDefaultAsync<Film>(
                    "GetFilmById",
                    new
                    {
                        Id = id
                    },
                    commandType: CommandType.StoredProcedure);

                FilmModel filmResponse = Mapper.Map<FilmModel>(film);

                return filmResponse;
            }
        }

        public async Task<IEnumerable<SessionModelResponse>> GetSessionsForFilm(int filmId)
        {
            using (SqlConnection connection = new SqlConnection(_settings.ConnectionString))
            {
                IEnumerable<SessionResponse> sessions = await connection.QueryAsync<SessionResponse>(
                    "GetAllSessionsForFilm",
                    new
                    {
                        FilmId = filmId
                    },
                    commandType: CommandType.StoredProcedure);

                return sessions.Select(Mapper.Map<SessionModelResponse>);
            }
        }

        public async Task<IEnumerable<SessionModelResponse>> SearchSessions(FilmFilterModel filters)
        {
            using (SqlConnection connection = new SqlConnection(_settings.ConnectionString))
            {
                IEnumerable<SessionResponse> sessions = await connection.QueryAsync<SessionResponse>(
                    "FilterFilms",
                    new
                    {
                        City = filters.City,
                        Cinema = filters.Cinema,
                        Film = filters.Film,
                        Date = filters.Date,
                        FreePlaces = filters.FreePlaces
                    },
                    commandType: CommandType.StoredProcedure);

                return sessions.Select(Mapper.Map<SessionModelResponse>);
            }
        }

        public async Task<int> AddOrUpdateFilm(FilmModel film)
        {
            using (SqlConnection connection = new SqlConnection(_settings.ConnectionString))
            {
                int id = await connection.ExecuteScalarAsync<int>(
                    "AddOrUpdateFilm",
                    new
                    {
                        Id = film.Id,
                        Name = film.Name,
                        Description = film.Description,
                        StartRentDate = film.StartRentDate,
                        EndRentDate = film.EndRentDate
                    },
                    commandType: CommandType.StoredProcedure);

                return id;
            }
        }
    }
}
