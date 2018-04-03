using JetBrains.Annotations;

namespace DataAccessLayer.Models.DataTransferObjects
{
    public class CinemaNamesDalDtoModel
    {
        [NotNull]
        public string Name;

        public CinemaNamesDalDtoModel(
            [NotNull] string name
        )
        {
            Name = name;
        }
    }
}
