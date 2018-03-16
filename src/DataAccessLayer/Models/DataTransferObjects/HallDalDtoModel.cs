using JetBrains.Annotations;

namespace DataAccessLayer.Models.DataTransferObjects
{
    [UsedImplicitly]
    public class HallDalDtoModel
    {
        public int Id { get;}

        public int CinemaId { get;}

        [NotNull]
        public string Name { get;}

        public HallDalDtoModel(
            int id,
            int cinemaId,
            [NotNull] string name
        )
        {
            Id = id;
            CinemaId = cinemaId;
            Name = name;
        }
    }
}
