using JetBrains.Annotations;

namespace DataAccessLayer.Models.DataTransferObjects
{
    [UsedImplicitly]
    public class HallDalDtoModel
    {
        public int Id { get;}

        public int CinemaId { get;}

        [NotNull]
        public string HallName { get; }

        [NotNull]
        public string CinemaName { get; }

        public HallDalDtoModel(
            int id,
            int cinemaId,
            [NotNull] string hallName,
            [NotNull] string cinemaName
        )
        {
            Id = id;
            CinemaId = cinemaId;
            HallName = hallName;
            CinemaName = cinemaName;
        }
    }
}
