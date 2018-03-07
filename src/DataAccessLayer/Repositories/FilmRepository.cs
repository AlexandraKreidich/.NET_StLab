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

                return films.Select(Mapper.Map<FilmModel>);
            }
        }

        public async Task<IEnumerable<FilmModel>> GetFilms()
        {
            using (SqlConnection connection = new SqlConnection(_settings.ConnectionString))
            {
                IEnumerable<Film> films = await connection.QueryAsync<Film>(
                    "GetFilms",
                    commandType: CommandType.StoredProcedure);

                IEnumerable<FilmModel> filmModels = films.Select(Mapper.Map<FilmModel>);

                return filmModels;
            }
        }

        public async Task<FilmModel> GetFilmById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_settings.ConnectionString))
            {
                Film film = await connection.QuerySingleOrDefaultAsync<Film>(
                    "GetFilms",
                    new
                    {
                        Id = id
                    },
                    commandType: CommandType.StoredProcedure);

                return Mapper.Map<FilmModel>(film);
            }
        }

        public async Task<IEnumerable<SessionModelResponseForFilmsCtrl>> GetSessionsForFilm(int filmId)
        {
            using (SqlConnection connection = new SqlConnection(_settings.ConnectionString))
            {
                IEnumerable<SessionResponseForFilmsCtrl> sessions = await connection.QueryAsync<SessionResponseForFilmsCtrl>(
                    "GetAllSessionsForFilm",
                    commandType: CommandType.StoredProcedure);

                return sessions.Select(Mapper.Map<SessionModelResponseForFilmsCtrl>);
            }
        }

        public async Task<IEnumerable<SessionModelResponseForFilmsCtrl>> SearchFilms(FilmFilterModel filters)
        {
            using (SqlConnection connection = new SqlConnection(_settings.ConnectionString))
            {
                IEnumerable<SessionResponseForFilmsCtrl> sessions = await connection.QueryAsync<SessionResponseForFilmsCtrl>(
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

                return sessions.Select(Mapper.Map<SessionModelResponseForFilmsCtrl>);
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
