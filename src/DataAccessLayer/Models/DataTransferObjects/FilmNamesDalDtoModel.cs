using JetBrains.Annotations;

namespace DataAccessLayer.Models.DataTransferObjects
{
    public class FilmNamesDalDtoModel
    {
        [NotNull] 
        public string Name;

        public FilmNamesDalDtoModel(
            [NotNull] string name
        )
        {
            Name = name;
        }
    }
}
