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

                return films.Select(Mapper.Map<FilmModel>);
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
    }
}
